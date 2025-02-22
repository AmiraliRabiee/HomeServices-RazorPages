using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Admin.Pages.Users
{
    public class UpdateModel(IUserAppService _userAppService , IBaseDataAppService _baseDataAppService) : PageModel
    {
        [BindProperty]
        public UserDto User { get; set; }
        [BindProperty]
        public List<City> Cities { get; set; }

        public void OnGet(int id)
        {
            Cities = _baseDataAppService.GetCities();
            User = _userAppService.GetDtoById(id);
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            await _userAppService.UpdateInformation(User, cancellationToken);
            return RedirectToPage("Index");

        }
    }
}
