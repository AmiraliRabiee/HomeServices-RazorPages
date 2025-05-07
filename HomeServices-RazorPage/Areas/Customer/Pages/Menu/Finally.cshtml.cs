using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
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
        public SummSuggestionDto? SuggestionDto { get; set; }
        [BindProperty]
        public AmountsDto Amounts { get; set; }
        [BindProperty]
        public AppUser? OnlineUser { get; set; }
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public ExpertDto? Expert { get; set; }
        public async Task OnGet(int id , CancellationToken cancellationToken)
        {
            TempData["OrderId"] = id;
            var constId = (int)TempData["OrderId"];

            SuggestionDto = await _suggestionAppService.GetSuggestionDto(id, cancellationToken);
            Amounts = await _baseDataAppService.GetAmountsData(SuggestionDto.Id, cancellationToken);
            OnlineUser = await _userManager.GetUserAsync(User);
            TempData["ExpertId"] = SuggestionDto.ExpertId;

            if (id == 0)
                return;
        }

        public async Task<IActionResult> OnPostWithdraw(float price, int orderId, int expertId, CancellationToken cancellationToken)
        {
            OnlineUser = await _userManager.GetUserAsync(User);
            var result = await _userAppService.Payment(OnlineUser, orderId, expertId, price, cancellationToken);

            if (result.IsSuccess)
            {
                TempData["Successfull"] = result.Message;
                return RedirectToPage("myorders");
            }

            TempData["Error"] = result.Message;
            return RedirectToPage(new { id = orderId }); // نمایش دوباره همان صفحه با پیام خطا
        }

    }
}
