using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Customer.Pages.Menu
{
    [Authorize(Roles = "Customer")]
    public class MyOrdersModel(IOrderAppService _orderAppService , UserManager<AppUser> userManager) : PageModel
    {
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public List<SummOrderDto> OrderDtos { get; set; }
        [BindProperty]
        public AppUser? OnlineUser { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            OnlineUser = await userManager.GetUserAsync(User);
            OrderDtos = await  _orderAppService.GetOrdersById(OnlineUser.Id, cancellationToken);
        }
    }
}
