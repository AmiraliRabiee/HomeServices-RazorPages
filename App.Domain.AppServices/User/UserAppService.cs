using App.Domain.AppServices.Base;
using App.Domain.AppServices.HomeService;
using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Contracts.Service.User;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Enum;
using Microsoft.AspNetCore.Identity;
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
        , IAdminService _adminService) : IUserAppService
    {
        public async Task<IdentityResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return IdentityResult.Failed(new IdentityError { Description = "نام کاربری و رمز عبور اجباری میباشد." });
            }

            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);
            return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed(new IdentityError { Description = "با خطا مواجه شد" });
        }



        public async Task<IdentityResult> Register(CreateUserDto
            model, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByNameAsync(model.UserName);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "این نام کاربری قبلا انتخاب شده ، لطفا نام دیگری را وارد کنید." });
            }

            bool cityExists = _baseDataService.GetCities().Any(city => city.Id == model.CityId);
            if (!cityExists)
            {
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
            };
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.ImagePath = model.ImagePath;

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
                    CityId = model.CityId,
                };
            }
            else if (model.RoleId == 3)
            {
                user.Expert = new Expert()
                {
                    CityId = model.CityId,
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

                var signInResult = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, true, false);
            }

            return result;
        }


        public async Task<IdentityResult> Logout()
        {
            await _signInManager.SignOutAsync();
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

        public async Task<CustomerDto> GetCustomerById(int id, CancellationToken cancellationToken)
            => await _customerService.GetCustomerDto(id, cancellationToken);


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

        public async Task<Result> CustomerUplpadingImage(UpdateUser model, UserDto user, CancellationToken cancellationToken)
        {
            if (model.ProfileImage is not null)
            {
                model.ImagePath = await _baseDataService.UploadImage(model.ProfileImage!, "Profiles", cancellationToken);
                if (model.ImagePath is not null)
                    user.ImagePath = model.ImagePath;
                _userService.UpdateCustomer2(user, cancellationToken);
                return new Result { IsSuccess = true, Message = "با موفقیت آپلود شد" };
            }
            return new Result { IsSuccess = false, Message = "آپلود عکس با مشکل مواجه شد" };
        }

        public async Task<Result> UpdateCustomer(CustomerDto model, CancellationToken cancellationToken)
        {
            var result = await _customerService.UpdateCustomer(model, cancellationToken);
            if (result.IsSuccess)
            {
                return new Result { IsSuccess = true, Message = ".کاربر به روزرسانی شد" };
            }
            return new Result { IsSuccess = false, Message = ".حذف کاربر با خطا مواجه شد" };
        }

        public List<AppUser> GetAll()
            => _userService.GetAll();

        public AppUser GetById(int id)
            => _userService.GetById(id);

        public UserDto GetDtoById(int id)
            => _userService.GetUserDto(id);

        public async Task<Result> Payment(AppUser user, int orderId, float price, CancellationToken cancellationToken)
        {
            var balance = await _userService.GetBalance(user, cancellationToken);

            if (balance == 0)
                return new Result { IsSuccess = false, Message = "موجودی حساب شما خالی میباشد" };
            if (balance < price)
                return new Result { IsSuccess = false, Message = "مبلغ سفارش بیشتر از مبلغ موجودی شما میباشد . لطفا افزایش موجودی انجام دهید" };
            if (balance >= price)
            {
                user.Balance = balance - price;
                var result = await _userService.UpdateBalance(user, cancellationToken);
                if (result.IsSuccess)
                {
                    await _orderService.ChangeToPayment(orderId, cancellationToken);
                    return new Result { IsSuccess = true, Message = "پرداخت با موفقیت انجام شد" };

                }
                return new Result { IsSuccess = false, Message = "در برداشت از حساب مشکلی پیش آمده است" };
            }
            return new Result { IsSuccess = false, Message = "با خطا مواجه شد" };
        }

        public async Task<Result> Receive(float price, CancellationToken cancellationToken)
        {
            var adminBalance = await _adminService.GetAdminBalance(cancellationToken);
            var profit = await _adminService.GetProfit(cancellationToken);

            adminBalance += price * profit;
            var result = await _adminService.UpdateBalance(adminBalance, cancellationToken);
            if (result.IsSuccess)
                return new Result { IsSuccess = true, Message = result.Message };
            return new Result { IsSuccess = false,Message= result.Message};
        }
    }
}
