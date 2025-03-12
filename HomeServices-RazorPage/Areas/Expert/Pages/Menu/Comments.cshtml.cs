using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Expert.Pages.Menu
{
    public class CommentsModel(ICommentAppService _commentAppService
        , ISuggestionAppService _suggestionAppService) : PageModel
    {
        [BindProperty]
        public List<CommentDto> Comments { get; set; }
        [BindProperty]
        public double? AverageScore { get; set; }
        [BindProperty]
        public int CommentCount { get; set; }
        [BindProperty]
        public int DoneSuggestions { get; set; }
        public async Task OnGet(int expertId, CancellationToken cancellationToken)
        {
            Comments = await _commentAppService.GetCommentsById(expertId, cancellationToken);

            AverageScore = await _commentAppService.GetAvg(expertId, cancellationToken);
            CommentCount = await _commentAppService.GetCount(expertId, cancellationToken);
            DoneSuggestions = await _suggestionAppService.DoneSuggestionsCount(expertId, cancellationToken);
        }
    }
}
