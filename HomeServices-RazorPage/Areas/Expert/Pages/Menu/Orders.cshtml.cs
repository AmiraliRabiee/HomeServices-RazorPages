using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Expert.Pages.Menu
{
    [Authorize(Roles = "Expert")]
    public class OrdersModel(IOrderAppService _orderAppService, UserManager<AppUser> _userManager) : PageModel
    {
        [BindProperty]
        public AppUser AppUser { get; set; }
        [BindProperty]
        public List<SummOrderDto> OrderDtos { get; set; }
        public int MyProperty { get; set; }
        public async Task OnGetAsync(int id , CancellationToken cancellationToken)
        {
            AppUser = await _userManager.GetUserAsync(User);
            OrderDtos = await _orderAppService.GetReserveOrders(AppUser, cancellationToken);

        }
    }
}
