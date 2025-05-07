using App.Domain.AppServices.HomeService;
using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace HomeServices_RazorPage.Areas.Expert.Pages.Menu
{
    public class ReservationsModel(ISuggestionAppService _suggestionAppService,UserManager<AppUser> _userManager ,IOrderAppService _orderAppService) : PageModel
    {
        [BindProperty]
        public AppUser AppUser { get; set; }
        [BindProperty]
        public List<SummOrderDto> OrderDtos { get; set; }
        [BindProperty]
        public List<SummSuggestionDto> ActiveSuggestions { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var expertId = UserTools.GetExpertId(User.Claims);
            ActiveSuggestions = await _suggestionAppService.ActiveSuggestions(expertId, cancellationToken);
            AppUser = await _userManager.GetUserAsync(User);
            OrderDtos = await _orderAppService.GetReserveOrders(AppUser, cancellationToken);
        }
    }
}