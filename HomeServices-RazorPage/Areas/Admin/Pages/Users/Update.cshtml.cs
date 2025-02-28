using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Serialization;

namespace HomeServices_RazorPage.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class UpdateModel(IUserAppService _userAppService , IBaseDataAppService _baseDataAppService) : PageModel
    {
        [BindProperty]
        public List<City> Cities { get; set; }

        [BindProperty]
        public UserDto NewUser { get; set; }
        [BindProperty]
        public string Message { get; set; }

        public void OnGet(int id)
        {
            Cities = _baseDataAppService.GetCities();
            NewUser = _userAppService.GetDtoById(id);
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken , int id)
        {
            Cities = _baseDataAppService.GetCities();
            var result = await _userAppService.UpdateInformation(NewUser, cancellationToken);
            if (result.IsSuccess)
            {
                Message = result.Message;
                return Page();
            }
            Message = result.Message;
            return Page();
        }
    }
}
