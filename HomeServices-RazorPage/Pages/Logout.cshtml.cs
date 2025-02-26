using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Pages
{
    public class LogoutModel(SignInManager<AppUser> signInManager) : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager = signInManager;

        public async Task<IActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();

            return RedirectToPage("Index");
        }

    }
}
