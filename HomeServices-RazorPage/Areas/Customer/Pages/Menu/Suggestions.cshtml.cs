using App.Domain.AppServices.User;
using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace HomeServices_RazorPage.Areas.Customer.Pages.Menu
{
    [Authorize(Roles = "Customer")]
    public class SuggestionsModel(ISuggestionAppService _suggestionAppService,IOrderAppService _orderAppService , ISuggestionRepository _suggestionRepository) : PageModel
    {
        [BindProperty]
        public List<SummSuggestionDto> SuggestionDtos { get; set; }
        [BindProperty]
        public AppUser OnlineUser { get; set; }
        [BindProperty]
        public string Message { get; set; }

        public async Task OnGet(int oId,CancellationToken cancellationToken)
        {
            SuggestionDtos = await _suggestionAppService.CheckSuggestions(oId, cancellationToken);
        }

        public async Task<IActionResult> OnGetAccept(int id, int orderNumber, CancellationToken cancellationToken)
        {
            var acception = await _suggestionAppService.AcceptSuggestion(id,orderNumber, cancellationToken);
            if (acception.IsSuccess)
            {
                Message = acception.Message;
                return RedirectToPage("myorders");
            }
            Message = acception.Message;
            return Page();
        }
    }
}
