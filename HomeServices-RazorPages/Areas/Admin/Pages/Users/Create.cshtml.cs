using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPages.Areas.Admin.Pages.Users
{
    public class CreateModel(IBaseDataAppService _baseDataAppService, IUserAppService _userAppService) : PageModel
    {
        [BindProperty]
        public CreateUserDto User { get; set; }

        [BindProperty]
        public List<City> Cities { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Cities = await _baseDataAppService.GetCities(cancellationToken);
        }


        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            await _userAppService.Register(User, cancellationToken);
            return RedirectToPage("Index");
        }
    }
}
