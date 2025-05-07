using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Expert.Pages.Menu
{
    //[Authorize(Roles = "Expert")]
    public class ContentModel(ISuggestionAppService _suggestionAppService,ICommentAppService _commentAppService
        ,IUserAppService _userAppService) : PageModel
    {
        [BindProperty]
        public ExpertDto? Expert { get; set; }
        [BindProperty]
        public List<CommentDto> Comments { get; set; }
        [BindProperty]
        public double? AverageScore { get; set; }
        [BindProperty]
        public int CommentCount { get; set; }
        [BindProperty]
        public int DoneSuggestions { get; set; }
        [BindProperty]
        public List<ExpertWorkDto> Skills { get; set; }
        public async Task OnGet(int id , CancellationToken cancellationToken)
        {
            Expert = await _suggestionAppService.GetExpertDto(id ,cancellationToken);
            AverageScore = await _commentAppService.GetAvg(id, cancellationToken);
            CommentCount = await _commentAppService.GetCount(id, cancellationToken);
            DoneSuggestions = await _suggestionAppService.DoneSuggestionsCount(id, cancellationToken);
            Skills = await _userAppService.GetExpertSkillsNameAsync(id, cancellationToken);
        }
    }
}
