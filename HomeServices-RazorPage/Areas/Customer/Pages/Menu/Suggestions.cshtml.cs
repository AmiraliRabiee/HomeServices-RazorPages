using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.HomeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Customer.Pages.Menu
{
    [Authorize(Roles = "Customer")]
    public class SuggestionsModel(IOrderAppService _orderAppService) : PageModel
    {
        [BindProperty]
        public List<SummOrderDto> Orders { get; set; }
        public async Task OnGet()

        {
            Orders = await _orderAppService.GetAll();
        }
    }
}
