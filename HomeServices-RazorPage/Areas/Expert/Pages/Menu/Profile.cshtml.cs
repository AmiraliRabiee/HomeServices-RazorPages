using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Expert.Pages.Menu
{
    [Authorize(Roles = "Expert")]
    public class ProfileModel(IUserAppService _userAppService, IBaseDataAppService _baseDataAppService, IHouseWorkAppService _houseWorkAppService) : PageModel
    {
        [BindProperty]
        public ExpertDto OnlineExpert { get; set; }
        [BindProperty]
        public List<City> Cities { get; set; }
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public List<SummHouseWorkDto> HousWorks { get; set; }
        [BindProperty]
        public UpdateUser UpdateUser { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var expertId = UserTools.GetExpertId(User.Claims);
            OnlineExpert = await _userAppService.GetExpertDto(expertId, cancellationToken);
            OnlineExpert.SelectedHouseWorkIds = await _userAppService.GetExpertSkills(expertId, cancellationToken);
            Cities = await _baseDataAppService.GetCitiesAsync(cancellationToken);
            HousWorks = await _houseWorkAppService.GetAll(cancellationToken);
        }

        public async Task<IActionResult> OnPostUpdate(List<int> houseWorkIds, CancellationToken cancellationToken)
        {
            var expertId = UserTools.GetExpertId(User.Claims);
            var expert = await _userAppService.GetExpertDto(expertId, cancellationToken);
            OnlineExpert.AppUser = expert.AppUser;

            await _userAppService.UpdateExpertSkills(expertId, houseWorkIds, cancellationToken);
            var result = await _userAppService.UpdateExpert(OnlineExpert, cancellationToken);
            if (result.IsSuccess)
            {
                Message = "مهارت‌ها با موفقیت بروزرسانی شدند.";
                return RedirectToPage("Profile");
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return Page();
        }


    }
}
