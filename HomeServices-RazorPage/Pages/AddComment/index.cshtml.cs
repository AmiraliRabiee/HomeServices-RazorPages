using App.Domain.AppServices.HomeService;
using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace HomeServices_RazorPage.Pages.AddComment
{
    public class IndexModel(ICommentAppService _commentAppService , ISuggestionAppService _suggestionAppService) : PageModel
    {
        [BindProperty]
        public SummSuggestionDto SuggestionDto { get; set; }
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public Comment NewComment { get; set; } = new Comment();

        public async Task OnGet(int id , CancellationToken cancellationToken)
        {
            SuggestionDto = await _suggestionAppService.GetExpertBySuggestion(id, cancellationToken);
            TempData["ExpertId"] = SuggestionDto.ExpertId;
        }

        public async Task<IActionResult> OnPost(int id , CancellationToken cancellationToken)
        {
            var customerId = UserTools.GetCustomerId(User.Claims);

            if (TempData["ExpertId"] is int expertId)
            {
                NewComment.CustomerId = customerId;
                NewComment.ExpertId = expertId;
                var result = await _commentAppService.Add(NewComment, cancellationToken);

                if (result.IsSuccess)
                {
                    Message = result.Message;
                    return RedirectToPage("/menu/dashboard", new {area = "customer"});
                }
                Message = result.Message;
            }
            return Page();
        }
    }
}
