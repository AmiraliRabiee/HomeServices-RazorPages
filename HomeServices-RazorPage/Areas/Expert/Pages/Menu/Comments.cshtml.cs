using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Expert.Pages.Menu
{
    public class CommentsModel(ICommentAppService _commentAppService
        , ISuggestionAppService _suggestionAppService
        ,IUserAppService _userAppService) : PageModel
    {
        [BindProperty]
        public List<CommentDto>? Comments { get; set; }
        [BindProperty]
        public double? AverageScore { get; set; }
        [BindProperty]
        public int CommentCount { get; set; }
        [BindProperty]
        public int DoneSuggestions { get; set; }
        [BindProperty]
        public ExpertDto? ExpertDto { get; set; }
        [BindProperty]
        public ExpertDto? ExpertDetails { get; set; }
        public async Task OnGet(int expertId, CancellationToken cancellationToken)
        {
            if (User.IsInRole("Expert"))
            {
                var id = UserTools.GetExpertId(User.Claims);
                Comments = await _commentAppService.GetCommentsById(id, cancellationToken);
                ExpertDto = await _userAppService.GetExpertDto(id, cancellationToken);
                ExpertDetails = await _suggestionAppService.GetExpertDto(id, cancellationToken);

            }
            else
            {
                ExpertDto = await _userAppService.GetExpertDto(expertId, cancellationToken);
                Comments = await _commentAppService.GetCommentsById(expertId, cancellationToken);
                ExpertDetails = await _suggestionAppService.GetExpertDto(expertId, cancellationToken);
            }
            AverageScore = await _commentAppService.GetAvg(expertId, cancellationToken);
            CommentCount = await _commentAppService.GetCount(expertId, cancellationToken);
            DoneSuggestions = await _suggestionAppService.DoneSuggestionsCount(expertId, cancellationToken);

        }
    }
}
