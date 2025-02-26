using App.Domain.Core.Contracts.AppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Account.Pages
{

    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LoginModel(IUserAppService userAppService) : PageModel
    {

        [BindProperty]
        public LoginViewModel PageUserModel { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await userAppService.Login(PageUserModel.Username, PageUserModel.Password);
            if (result.Succeeded)
                return RedirectToPage("Index");
            return Page();
        }
    }
}
