using App.Domain.Core.Contracts.AppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Pages.AddComment
{
    public class Index1Model(ICommentAppService _commentAppService) : PageModel
    {
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public Comment NewComment { get; set; } = new Comment();
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var result = await _commentAppService.Add(NewComment, cancellationToken);
            if (result.IsSuccess && ModelState.IsValid)
            {
                Message = result.Message;
                return RedirectToPage("index");
            }
            Message = result.Message;
            return Page();
        }
    }
}
