using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace HomeServices_RazorPage.Areas.Expert.Pages.Menu
{
    [Authorize(Roles = "Expert")]
    public class ProfileModel(IUserAppService _userAppService,
        IBaseDataAppService _baseDataAppService,
        IHouseWorkAppService _houseWorkAppService) : PageModel
    {
        private const int MaxSkillUpdates = 3; // Maximum allowed skill updates
        private static readonly TimeSpan CooldownPeriod = TimeSpan.FromHours(12); // Cooldown time

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

        [BindProperty]
        public int SkillUpdateCount { get; set; }

        [BindProperty]
        public DateTime? LastSkillUpdate { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var expertId = UserTools.GetExpertId(User.Claims);
            OnlineExpert = await _userAppService.GetExpertDto(expertId, cancellationToken);
            OnlineExpert.SelectedHouseWorkIds = await _userAppService.GetExpertSkills(expertId, cancellationToken);
            Cities = await _baseDataAppService.GetCitiesAsync(cancellationToken);
            HousWorks = await _houseWorkAppService.GetAll(cancellationToken);
            SkillUpdateCount = await _userAppService.GetSkillUpdateCount(expertId, cancellationToken);
            LastSkillUpdate = await _userAppService.GetLastSkillUpdateDate(expertId, cancellationToken);
        }

        public async Task<IActionResult> OnPostUpdate(List<int> houseWorkIds, CancellationToken cancellationToken)
        {
            var expertId = UserTools.GetExpertId(User.Claims);
            var expert = await _userAppService.GetExpertDto(expertId, cancellationToken);
            OnlineExpert.AppUser = expert.AppUser;

            SkillUpdateCount = await _userAppService.GetSkillUpdateCount(expertId, cancellationToken);
            LastSkillUpdate = await _userAppService.GetLastSkillUpdateDate(expertId, cancellationToken);

            // Check if expert has exceeded the limit
            if (SkillUpdateCount >= MaxSkillUpdates)
            {
                if (LastSkillUpdate.HasValue && (DateTime.UtcNow - LastSkillUpdate.Value) < CooldownPeriod)
                {
                    Message = $"شما بیش از حد مجاز مهارت‌های خود را تغییر داده‌اید. لطفا {CooldownPeriod.TotalHours} ساعت صبر کنید.";
                    return Page();
                }
                else
                {
                    // Reset skill update count after cooldown
                    await _userAppService.ResetSkillUpdateCount(expertId, cancellationToken);
                    SkillUpdateCount = 0;
                }
            }

            // Update skills and set new last update date
            await _userAppService.UpdateExpertSkills(expertId, houseWorkIds, cancellationToken);
            await _userAppService.IncrementSkillUpdateCount(expertId, cancellationToken);
            await _userAppService.UpdateLastSkillUpdateDate(expertId, DateTime.UtcNow, cancellationToken);

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
