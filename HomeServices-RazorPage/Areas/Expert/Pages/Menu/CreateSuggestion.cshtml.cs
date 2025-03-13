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
            TempData.Keep("OrderId");

            OrderDto = await _orderAppService.GetOrderById(orderId, cancellationToken);

            NewSuggestion.OrderId = orderId;
            NewSuggestion.ExpertId = expertId;


            var lastSuggestion = await _suggestionAppService.GetLastSuggestion(expertId, orderId, cancellationToken);

            if (lastSuggestion != null && (DateTime.UtcNow - lastSuggestion.CreatedAt).TotalHours < 24)
            {
                ModelState.AddModelError(string.Empty, "شما فقط یک پیشنهاد در روز می‌توانید ثبت کنید.");
                return Page();
            }

            var result = await _suggestionAppService.Create(NewSuggestion ,OrderDto.BasePrice, cancellationToken);
            if (result.IsSuccess)
            {
                Message = result.Message;
                TempData["Success"] = "پیشنهاد با موفقیت ثبت شد";
                return RedirectToPage("reservations");
            }
            Message = result.Message;
            return Page();
        }
    }
}
