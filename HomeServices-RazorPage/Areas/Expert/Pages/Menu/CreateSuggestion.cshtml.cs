using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Expert.Pages.Menu
{
    [Authorize(Roles = "Expert")]
    public class CreateSuggestionModel(ISuggestionAppService _suggestionAppService, IOrderAppService _orderAppService) : PageModel
    {
        [BindProperty]
        public Suggestion NewSuggestion { get; set; } = new Suggestion();
        [BindProperty]
        public SummOrderDto OrderDto { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public async Task OnGetAsync(int orderId, CancellationToken cancellationToken)
        {
            OrderDto = await _orderAppService.GetOrderById(orderId, cancellationToken);
            TempData["OrderId"] = OrderDto.Id;
        }

        public async Task<IActionResult> OnPostCreate(CancellationToken cancellationToken)
        {
            var expertId = UserTools.GetExpertId(User.Claims);
            int orderId = (int)TempData["OrderId"];
            
            NewSuggestion.OrderId = orderId;
            NewSuggestion.ExpertId = expertId;

            var result = await _suggestionAppService.Create(NewSuggestion, cancellationToken);
            if (result.IsSuccess)
            {
                Message = result.Message;
                return RedirectToPage("dashboard");
            }
            Message = result.Message;
            return Page();
        }
    }
}
