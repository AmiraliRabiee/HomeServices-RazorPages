using App.Domain.AppServices.Base;
using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Contracts.Repository.User;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Expert.Pages.Menu
{
    //[Authorize(Roles = "Expert")]
    public class ContentModel(ISuggestionAppService _suggestionAppService, ISuggestionRepository suggestionRepository,ICommentAppService _commentAppService) : PageModel
    {
        [BindProperty]
        public ExpertDto Expert { get; set; }
        [BindProperty]
        public List<CommentDto> Comments { get; set; }
        [BindProperty]
        public double? AverageScore { get; set; }
        [BindProperty]
        public int CommentCount { get; set; }
        [BindProperty]
        public int DoneSuggestions { get; set; }
        public async Task OnGet(int id , CancellationToken cancellationToken)
        {
            Expert = await suggestionRepository.GetExpertDto(id ,cancellationToken);
            AverageScore = await _commentAppService.GetAvg(id, cancellationToken);
            CommentCount = await _commentAppService.GetCount(id, cancellationToken);
            DoneSuggestions = await _suggestionAppService.DoneSuggestionsCount(id, cancellationToken);
        }
    }
}
