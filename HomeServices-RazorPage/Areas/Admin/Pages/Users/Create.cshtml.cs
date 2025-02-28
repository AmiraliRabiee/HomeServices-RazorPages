using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.OutputResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class CreateModel(IBaseDataAppService _baseDataAppService, IUserAppService _userAppService) : PageModel
    {
        [BindProperty]
        public CreateUserDto User { get; set; }

        [BindProperty]
        public List<City> Cities { get; set; }

        public IdentityResult? Result { get; set; }

        public async Task OnGet()
        {
            Cities = _baseDataAppService.GetCities();
        }


        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Result = await _userAppService.Register(User,cancellationToken);

            if (Result.Succeeded)
            {
                RedirectToPage("/Index");
            }

            foreach (var error in Result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}
