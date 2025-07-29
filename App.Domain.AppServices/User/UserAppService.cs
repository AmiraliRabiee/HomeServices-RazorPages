using App.Domain.AppServices.Base;
using App.Domain.AppServices.HomeService;
using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Contracts.Service.User;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Enum;
using App.Domain.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading;

namespace App.Domain.AppServices.User
{
    public class UserAppService(SignInManager<AppUser> _signInManager,
        UserManager<AppUser> _userManager
        , IBaseDataService _baseDataService
        , IUserService _userService
        , IExpertService _expertService
        , ICustomerService _customerService
        , ISuggestionService _suggestionService
        , IOrderService _orderService
        , IAdminService _adminService
        ,IJwtService _jwtService
        ,ILogger<UserAppService> _logger
        , IHttpContextAccessor _httpContextAccessor) : IUserAppService
    {
        public async Task<IdentityResult> Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return IdentityResult.Failed(new IdentityError { Description = "نام کاربری و رمز عبور اجباری می‌باشد." });
            }

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "کاربری با این مشخصات یافت نشد." });
            }

            if (user.ActivationUser == ActivationEnum.Pending)
            {
                _logger.LogInformation("کاربر {Username} تلاش برای ورود داشت اما حساب در حالت انتظار تایید است.", username);
                return IdentityResult.Failed(new IdentityError { Description = "حساب کاربری شما هنوز تایید نشده است. لطفا منتظر تایید مدیر باشید." });
            }

            var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation("کاربر {Username} با موفقیت وارد شد.", username);
                return IdentityResult.Success;
            }
            else
            {
                _logger.LogWarning("تلاش ناموفق برای ورود کاربر {Username}.", username);
                return IdentityResult.Failed(new IdentityError { Description = "نام کاربری یا رمز عبور اشتباه است." });
            }
        }



        public async Task<IdentityResult> Register(CreateUserDto model, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByNameAsync(model.UserName);
            if (existingUser != null)
            {
                _logger.LogWarning("ثبت‌نام ناموفق: نام کاربری {Username} تکراری است.", model.UserName);
                return IdentityResult.Failed(new IdentityError { Description = "این نام کاربری قبلا انتخاب شده ، لطفا نام دیگری را وارد کنید." });
            }

            bool cityExists = (await _baseDataService.GetCitiesAsync(cancellationToken)).Any(city => city.Id == model.CityId);
            if (!cityExists)
            {
                _logger.LogWarning("ثبت‌نام ناموفق: شهر با شناسه {CityId} یافت نشد.", model.CityId);
                return IdentityResult.Failed(new IdentityError { Description = "شهر انتخابی معتبر نمی باشد." });
            }

            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                RoleId = model.RoleId,
                PhoneNumber = model.PhoneNumber,
                ImagePath = model.ImagePath
            };

            string role = model.RoleId switch
            {
                2 => "Customer",
                3 => "Expert",
                _ => throw new InvalidOperationException("نقش کاربر معتبر نمی باشد.")
            };

            if (model.RoleId == 2)
            {
                user.Customer = new Customer()
                {
                    Address = model.Address,
                    CityId = model.CityId
                };
            }
            else if (model.RoleId == 3)
            {
                user.Expert = new Expert()
                {
                    CityId = model.CityId
                };
            }

            user.RegisterAt = DateTime.Now;

            if (model.ProfileImgFile is not null)
            {
                user.ImagePath = await _baseDataService.UploadImage(model.ProfileImgFile!, "Profiles", cancellationToken);
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);

                if (model.RoleId == 2)
                {
                    await _userManager.AddClaimAsync(user, new Claim("CustomerId", user.Customer!.Id.ToString()));
                }
                else if (model.RoleId == 3)
                {
                    await _userManager.AddClaimAsync(user, new Claim("ExpertId", user.Expert!.Id.ToString()));
                }

                user.ActivationUser = ActivationEnum.Pending;
                await _userManager.AddClaimAsync(user, new Claim("ActivationUser", "Pending"));
                var signInResult = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, true, false);

                _logger.LogInformation($"کاربر جدید با نام کاربری {user.Id} و نقش {user.RoleId} با موفقیت ثبت شد. شناسه کاربر",
                    user.UserName, role, user.Id);
            }
            else
            {
                _logger.LogError("ثبت‌نام ناموفق برای کاربر {Username}. دلایل: {Errors}",
                    model.UserName, string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            return result;
        }


        public async Task<IdentityResult> Logout()
        {
            var username = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "ناشناس";

            await _signInManager.SignOutAsync();

            _logger.LogInformation("کاربر {Username} خارج شد.", username);

            return IdentityResult.Success;
        }


        public async Task<Result> RemoveUser(int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.DeleteUser(id, cancellationToken);
                if (result.IsSuccess)
                    return new Result { IsSuccess = true, Message = result.Message };
                return result;
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<CustomerDto?> GetCustomerById(int id, CancellationToken cancellationToken)
        {
            var customer = await _customerService.GetCustomerDto(id, cancellationToken);

            if (customer is null)
                throw new NotFoundException($"مشتری با شناسه {id} یافت نشد.");

            return customer;
        }


        public async Task<Result> UpdateInformation(UserDto model, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.UpdateUser(model, cancellationToken);
                if (result.IsSuccess)
                    return new Result { IsSuccess = true, Message = ".کاربر به روزرسانی شد" };
                return new Result { IsSuccess = false, Message = ".به روزرسانی کاربر با خطا مواجه شد" };

            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<Result> UpdateCustomerInformation(UserDto model, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.UpdateCustomer(model, cancellationToken);
                if (result.IsSuccess)
                    return new Result { IsSuccess = true, Message = ".کاربر به روزرسانی شد" };
                return new Result { IsSuccess = false, Message = ".به روزرسانی کاربر با خطا مواجه شد" };

            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<Result> UpdateExpert(ExpertDto model, CancellationToken cancellationToken)
        {
            if (model.ExpertImage is not null)
            {
                model.ImagePath = await _baseDataService.UploadImage(model.ExpertImage!, "Profiles", cancellationToken);
            }
            var result = await _expertService.UpdateExpert(model, cancellationToken);
            if (result.IsSuccess)
                return new Result { IsSuccess = true, Message = result.Message };
            return new Result { IsSuccess = false, Message = result.Message };
        }

        public async Task<Result> UplpadingImage(UpdateUser model, AppUser user, CancellationToken cancellationToken)
        {
            if (model.ProfileImage is not null)
            {
                model.ImagePath = await _baseDataService.UploadImage(model.ProfileImage!, "Profiles", cancellationToken);
                if (model.ImagePath is not null)
                    user.ImagePath = model.ImagePath;
                await _userService.UpdateImage(user, cancellationToken);
                return new Result { IsSuccess = true, Message = "با موفقیت آپلود شد" };
            }
            return new Result { IsSuccess = false, Message = "آپلود عکس با مشکل مواجه شد" };
        }

        public async Task<Result> UpdateCustomer(CustomerDto model, CancellationToken cancellationToken)
        {
            if (model.CustomerImage is not null)
            {
                model.ImagePath = await _baseDataService.UploadImage(model.CustomerImage!, "Profiles", cancellationToken);
            }
            var result = await _customerService.UpdateCustomer(model, cancellationToken);
            if (result.IsSuccess)
            {
                return new Result { IsSuccess = true, Message = ".کاربر به روزرسانی شد" };
            }
            return new Result { IsSuccess = false, Message = ".حذف کاربر با خطا مواجه شد" };
        }

        public async Task<List<UserDto>> GetAll(CancellationToken cancellationToken)
            => await _userService.GetAll(cancellationToken);

        public AppUser GetById(int id)
            => _userService.GetById(id);

        public UserDto GetDtoById(int id)
            => _userService.GetUserDto(id);

        public async Task<Result> Payment(AppUser user, int orderId, int expertId, float price, CancellationToken cancellationToken)
        {
            var payment = await _userService.Payment(user, orderId, price, cancellationToken);
            if (!payment.IsSuccess)
            {
                return payment;
            }

            var receive = await _userService.ExpertReceive(user, price, cancellationToken);
            var result = await _userService.AdminReceive(price, cancellationToken);

            if (result.IsSuccess && receive.IsSuccess)
            {
                return new Result { IsSuccess = true, Message = "عملیات پرداخت با موفقیت انجام شد" };
            }

            return new Result { IsSuccess = false, Message = "پرداخت با خطا مواجه شد" };
        }


        public async Task<ExpertDto?> GetExpertDto(int id, CancellationToken cancellationToken)
        {
            var expert = await _expertService.GetExpertDto(id, cancellationToken);
            if (expert == null)
                throw new NotFoundException("کارشناس با این شناسه یافت نشد.");
            return expert;
        }

        public async Task<List<int>> GetExpertSkills(int expertId, CancellationToken cancellationToken)
            => await _expertService.GetExpertSkills(expertId, cancellationToken);

        public async Task UpdateExpertSkills(int expertId, List<int> houseWorkIds, CancellationToken cancellationToken)
            => await _expertService.UpdateExpertSkills(expertId, houseWorkIds, cancellationToken);

        public async Task<List<ExpertWorkDto>> GetExpertSkillsNameAsync(int expertId, CancellationToken cancellationToken)
            => await _expertService.GetExpertSkillsNameAsync(expertId, cancellationToken);

        public async Task<int> GetSkillUpdateCount(int expertId, CancellationToken cancellationToken)
            => await _expertService.GetSkillUpdateCount(expertId, cancellationToken);

        public async Task IncrementSkillUpdateCount(int expertId, CancellationToken cancellationToken)
            => await _expertService.IncrementSkillUpdateCount(expertId, cancellationToken);

        public async Task<DateTime?> GetLastSkillUpdateDate(int expertId, CancellationToken cancellationToken)
            => await _expertService.GetLastSkillUpdateDate(expertId, cancellationToken);

        public async Task UpdateLastSkillUpdateDate(int expertId, DateTime updateDate, CancellationToken cancellationToken)
            => await _expertService.UpdateLastSkillUpdateDate(expertId, updateDate, cancellationToken);

        public async Task ResetSkillUpdateCount(int expertId, CancellationToken cancellationToken)
            => await _expertService.ResetSkillUpdateCount(expertId, cancellationToken);

        public async Task AcceptUserAsync(int id)
            => await _userService.AcceptUser(id);

        public async Task RejectUserAsync(int id)
            => await (_userService.RejectUser(id));
    }
}
