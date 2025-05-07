using App.Domain.Core.Contracts.AppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Enum;

namespace HomeServices_RazorPage.Pages
    {
        public class LoginViewModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public bool RememberMe { get; set; }
        }

        public class LoginModel : PageModel
        {
            private readonly IUserAppService _userAppService;
            private readonly UserManager<AppUser> _userManager;

            public LoginModel(IUserAppService userAppService, UserManager<AppUser> userManager)
            {
                _userAppService = userAppService;
                _userManager = userManager;
            }

            [BindProperty]
            public LoginViewModel PageModel { get; set; }


        public async Task<IActionResult> OnPost()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                // بررسی وضعیت تأیید حساب کاربری
                var user = await _userManager.FindByNameAsync(PageModel.Username);
                if (user != null && user.ActivationUser == ActivationEnum.Pending)
                {
                    ModelState.AddModelError(string.Empty, "حساب شما در انتظار تأیید مدیریت است.");
                    return Page();
                }

                var result = await _userAppService.Login(PageModel.Username, PageModel.Password);
                if (result.Succeeded)
                {
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToPage("/Index", new { area = "Admin" });
                    }

                    return RedirectToPage("Index");
                }

                ModelState.AddModelError(string.Empty, "نام کاربری یا رمز عبور اشتباه است.");
                return Page();
            }
        }
    }
