using App.Domain.AppServices.Base;
using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.BaseEntities;
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
        , ICustomerService _customerService) : IUserAppService
    {
        public async Task<IdentityResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return IdentityResult.Failed(new IdentityError { Description = "نام کاربری و رمز عبور اجباری میباشد." });
            }
            var user = await _userManager.FindByNameAsync(username);

            if (user is null)
                return IdentityResult.Failed(new IdentityError { Description = "کاربر پیدا نشد." });

            var result = await _signInManager.PasswordSignInAsync(user, password, true, false);
            return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed(new IdentityError { Description = "با خطا مواجه شد" });
        }

        public async Task<IdentityResult> Register(CreateUserDto model, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
            {
                return IdentityResult.Failed(new IdentityError { Description = "نام کاربری و رمز عبور اجباری میباشد." });
            }

            var existingUser = await _userManager.FindByNameAsync(model.UserName);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "این نام کاربری قبلا انتخاب شده ، لطفا نام دیگری را وارد کنید." });
            }

            if (model.Password != model.RePassword)
            {
                return IdentityResult.Failed(new IdentityError { Description = "رمز عبور و تکرار آن باید یکسان باشند." });
            }

            bool cityExists = _baseDataService.GetCities().Any(city => city.Id == model.CityId);
            if (!cityExists)
            {
                return IdentityResult.Failed(new IdentityError { Description = "شهر انتخابی معتبر نمی باشد." });
            }

            var user = new AppUser
            {
                UserName = model.UserName,
                Password = model.Password,
                RePassword = model.RePassword,
                RoleId = model.RoleId

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
                    CityId = model.CityId,
                    Id = user.Id
                };
            }
            else if (model.RoleId == 3)
            {
                user.Expert = new Expert()
                {
                    CityId = model.CityId,
                     Id = user.Id
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
                if (!signInResult.Succeeded)
                {
                    // Handle sign-in failure
                }
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
                //if (model.RoleId == 2)
                //{
                //    var delete = await _customerService.DeleteCustomer(model.Id, cancellationToken);
                //    if (delete.IsSuccess)
                //        return new Result { Message = ".کاربر حذف شد" };
                //    return new Result { Message = ".حذف کاربر با خطا مواجه شد" };
                //}
                //if (model.RoleId == 3)
                //{
                //    var delete = await _expertService.DeleteExpert(model.Id, cancellationToken);
                //    if (delete.IsSuccess)
                //        return new Result { Message = ".کاربر حذف شد" };
                //    return new Result { Message = ".حذف کاربر با خطا مواجه شد" };
                //}
                //return new Result { IsSuccess = false };
                if (result.IsSuccess)
                    return new Result { IsSuccess = true, Message = result.Message };
                return result;
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<Result> UpdateInformation(UserDto model, CancellationToken cancellationToken)
        {
            try
            {
                if (model.RoleId == 2)
                {
                    if (model.ProfileImgFile is not null)
                    {
                        model.ImagePath = await _baseDataService.UploadImage(model.ProfileImgFile!, "Profiles", cancellationToken);
                    }
                    var update1 = await _customerService.UpdateCustomer(model.Customer, cancellationToken);
                    if (update1.IsSuccess)
                    {
                        return new Result {IsSuccess = true, Message = ".کاربر به روزرسانی شد" };
                    }
                    return new Result {IsSuccess = false , Message = ".حذف کاربر با خطا مواجه شد" };
                }
                if (model.RoleId == 3)
                {
                    if (model.ProfileImgFile is not null)
                    {
                        model.ImagePath = await _baseDataService.UploadImage(model.ProfileImgFile!, "Profiles", cancellationToken);
                    }
                    var update2 = await _expertService.UpdateExpert(model.Expert, cancellationToken);
                    if (update2.IsSuccess)
                    {
                        return new Result {IsSuccess = true, Message = ".کاربر به روزرسانی شد" };
                    }
                    return new Result {IsSuccess = false, Message = ".حذف کاربر با خطا مواجه شد" };
                }
                return new Result { IsSuccess = false };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public List<AppUser> GetAll()
            => _userService.GetAll();

        public AppUser GetById(int id)
            => _userService.GetById(id);

        public UserDto GetDtoById(int id)
            => _userService.GetUserDto(id);

    }
}
