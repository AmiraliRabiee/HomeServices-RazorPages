using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPages.Pages
{
    public class RegisterModel(IUserAppService _userAppService) : PageModel
    {
        [BindProperty]
        public CreateUserDto User { get; set; }


        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            var result = await _userAppService.Register(User, cancellationToken);

            if (result.Succeeded)
            {
                return RedirectToPage("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}
