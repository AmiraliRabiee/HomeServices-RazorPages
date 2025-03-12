using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Expert.Pages.Menu
{
    [Authorize(Roles = "Expert")]
    public class DashboardModel(IHouseWorkAppService _houseWorkAppService 
        , IBaseDataAppService _baseDataAppService
        ,ISuggestionAppService _suggestionAppService) : PageModel
    {
        [BindProperty]
        public List<SummSuggestionDto> DoneSuggestions { get; set; }
        [BindProperty]
        public List<SummSuggestionDto> ActiveSuggestions { get; set; }
        [BindProperty]
        public StatisticsExpertDto statisticsExpert { get; set; }

        public async Task OnGetAsync(CancellationToken cancellationToken)
        {
            var expertId = UserTools.GetExpertId(User.Claims);
            statisticsExpert = await _baseDataAppService.GetStatisticsExpert(expertId, cancellationToken);
            DoneSuggestions = await _suggestionAppService.DoneSuggestions(expertId, cancellationToken);
            ActiveSuggestions = await _suggestionAppService.ActiveSuggestions(expertId, cancellationToken);
        }
    }
}
