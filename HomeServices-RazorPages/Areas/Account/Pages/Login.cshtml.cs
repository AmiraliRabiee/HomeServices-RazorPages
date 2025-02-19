using App.Domain.Core.Contracts.AppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPages.Areas.Account.Pages
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
        public LoginViewModel PageModel { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await userAppService.Login(PageModel.Username, PageModel.Password);
            if (result.Succeeded)
                return RedirectToPage("Index");
            return Page();
        }
    }
}
