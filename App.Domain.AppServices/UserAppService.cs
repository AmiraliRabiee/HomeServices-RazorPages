using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Enum;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading;

namespace App.Domain.AppServices
{
    public class UserAppService(SignInManager<AppUser> _signInManager, UserManager<AppUser> _userManager,IBaseDataService _baseDataService) : IUserAppService
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
            string role = string.Empty;

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

            var user = new AppUser
            {
                UserName = model.UserName,
                Password = model.Password,
                RePassword = model.RePassword,
            };

            if (model.Role == RoleEnum.Admin)
            {
                role = "Admin";
            }
            else if (model.Role == RoleEnum.Customer)
            {
                role = "Customer";
                user.Customer = new Customer()
                {
                    Address = model.Address,
                };
            }
            else if (model.Role == RoleEnum.Expert)
            {
                role = "Expert";
                user.Expert = new Expert()
                {
                    CityId = model.City.Id,
                };
            }
            else
            {
                return IdentityResult.Failed(new IdentityError { Description = "نقش کاربر معتبر نمی باشد." });
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                if (model.ProfileImgFile is not null)
                {
                    model.ImagePath = await _baseDataService.UploadImage(model.ProfileImgFile!, "Profiles", cancellationToken);
                }

                await _userManager.AddToRoleAsync(user, role);


                if (model.Role == RoleEnum.Customer)
                {
                    await _userManager.AddClaimAsync(user, new Claim("CustomerId", user.Customer.Id.ToString()));
                }

                if (model.Role == RoleEnum.Expert)
                {
                    await _userManager.AddClaimAsync(user, new Claim("ExpertId", user.Expert.Id.ToString()));
                }

                var signInResult = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, true, false);
                if (!signInResult.Succeeded)
                {
                    // Handle sign-in failure (e.g., log the error or return a specific message)
                }
            }
            return result;
        }

        public async Task<IdentityResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return IdentityResult.Success;
        }
    }
}
