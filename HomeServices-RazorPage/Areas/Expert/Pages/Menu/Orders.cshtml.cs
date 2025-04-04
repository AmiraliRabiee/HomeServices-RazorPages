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
        public SummOrderDto OrderDto { get; set; }
        [BindProperty]
        public float SuggestPrice { get; set; }
        public int MyProperty { get; set; }
        public async Task OnGetAsync(int id , CancellationToken cancellationToken)
        {
            AppUser = await _userManager.GetUserAsync(User);
            OrderDto = await _orderAppService.GetOrderById(id ,cancellationToken);
            SuggestPrice = await _orderAppService.GetSuggestPrice(id ,cancellationToken);
        }

    }
}
