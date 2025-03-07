using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Contracts.Repository.User;
using App.Domain.Core.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Expert.Pages.Menu
{
    //[Authorize(Roles = "Expert")]
    public class ContentModel(ISuggestionAppService _suggestionAppService, ISuggestionRepository suggestionRepository) : PageModel
    {
        [BindProperty]
        public ExpertDto Expert { get; set; }

        public async Task OnGet(int id , CancellationToken cancellationToken)
        {
            //Expert = await _suggestionAppService.GetExPertDto(id, cancellationToken);
            Expert = await suggestionRepository.GetExpertDto(id ,cancellationToken);
        }
    }
}
