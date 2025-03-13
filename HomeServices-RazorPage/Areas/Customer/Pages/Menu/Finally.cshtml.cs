using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Customer.Pages.Menu
{
    public class FinallyModel(IBaseDataAppService _baseDataAppService , ISuggestionAppService _suggestionAppService 
        , IUserAppService _userAppService , UserManager<AppUser> _userManager , ICommentAppService _commentAppService,IOrderAppService _orderAppService) : PageModel
    {
        [BindProperty]
        public SummSuggestionDto SuggestionDto { get; set; }
        [BindProperty]
        public AmountsDto Amounts { get; set; }
        [BindProperty]
        public AppUser OnlineUser { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public async Task OnGet(int id , CancellationToken cancellationToken)
        {
            TempData["OrderId"] = id;
            SuggestionDto = await _suggestionAppService.GetSuggestionDto(id, cancellationToken);
            TempData["ExpertId"] = SuggestionDto.ExpertId;
            Amounts = await _baseDataAppService.GetAmountsData(SuggestionDto.Id, cancellationToken);
            OnlineUser = await _userManager.GetUserAsync(User);
            if (id == 0)
                return;
        }

        public async Task<IActionResult> OnGetWithdraw(float price, CancellationToken cancellationToken)
        {
            if (TempData["OrderId"] is int orderId)
            {
                var expertId = (int)TempData["ExpertId"];

                OnlineUser = await _userManager.GetUserAsync(User);
                var payment = await _userAppService.Payment(OnlineUser, orderId, price, cancellationToken);
                var recive = await _userAppService.ExpertReceive(expertId, price, cancellationToken);
                var result = await _userAppService.AdminReceive(price, cancellationToken);
                if (result.IsSuccess)
                {
                    await _orderAppService.ChangeToPayment(orderId, cancellationToken);
                    Message = result.Message;
                    TempData["Successfull"] = "پرداخت با موفقیت انجام شد";
                    return RedirectToPage("myorders");
                }
                Message = result.Message;
                TempData["Error"] = "پزداخت با خطا مواجه شد . دوباره تلاش کنید";

            }
            return Page();
        }
    }
}
