using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Pages
{
    public class RegisterModel(IUserAppService _userAppService) : PageModel
    {
        [BindProperty]
        public CreateUserDto User { get; set; } = new CreateUserDto();


        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _userAppService.Register(User, cancellationToken);

                if (result.Succeeded)
                {
                    return RedirectToPage("index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }
    }
}
