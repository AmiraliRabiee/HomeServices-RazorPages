using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.HomeService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Admin.Pages.Sugeestions
{
    public class IndexModel(ISuggestionAppService _suggestionAppService) : PageModel
    {
        [BindProperty]
        public List<SummSuggestionDto> Suggestions { get; set; }
        public async Task OnGet(int id , CancellationToken cancellationToken)
        {
            Suggestions =  await _suggestionAppService.GetSuggestionDetails(id , cancellationToken);
        }
    }
}
