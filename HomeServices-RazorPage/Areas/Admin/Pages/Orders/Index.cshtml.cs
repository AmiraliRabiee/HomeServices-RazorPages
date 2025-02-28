using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Admin.Pages.Orders
{
    [Authorize(Roles = "Admin")]
    public class IndexModel(IOrderAppService _orderAppService) : PageModel
    {
        [BindProperty]
        public List<SummOrderDto> Orders { get; set; }
        public async Task OnGet()
        {
            Orders = await _orderAppService.GetAll();
        }

        public async Task<IActionResult> OnPostChangeStatus(int orderId, CancellationToken cancellationToken)
        {
            var result = await _orderAppService.ChangeStatus(orderId, cancellationToken);
            if (result.IsSuccess)
            {
                TempData["SuccessMessage"] = result.Message;
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }
            return RedirectToPage();
        }
    }
}
