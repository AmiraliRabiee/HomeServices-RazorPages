using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Expert.Pages.Menu
{
    public class AcceptedModel(IOrderAppService _orderAppService,UserManager<AppUser> userManager) : PageModel
    {
        [BindProperty]
        public AppUser AppUser { get; set; }
        [BindProperty]
        public List<SummOrderDto> OrderDtos { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            AppUser =await  userManager.GetUserAsync(User);
            OrderDtos = await _orderAppService.GetAcceptedOrders(AppUser, cancellationToken);
        }

        public async Task<IActionResult> OnPostChange(int id, CancellationToken cancellationToken)
        {
            await _orderAppService.ChangeToDone(id, cancellationToken);
            return RedirectToPage("accepted");
        }
    }
}
