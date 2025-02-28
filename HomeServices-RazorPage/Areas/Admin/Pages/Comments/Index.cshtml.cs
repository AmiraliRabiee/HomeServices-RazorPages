using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Admin.Pages.Comments
{
    [Authorize(Roles = "Admin")]
    public class IndexModel(ICommentAppService _commentAppService) : PageModel
    {
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public List<CommentDto> CommntsList { get; set; }
        public void OnGet()
        {
            CommntsList = _commentAppService.GetComments();
        }

        public async Task OnGetDelete(int id,CancellationToken cancellationToken)
        {
            CommntsList = _commentAppService.GetComments();
            var result = await _commentAppService.Delete(id , cancellationToken);
            if(result.IsSuccess)
                Message= result.Message;
            Message = result.Message;
        }
        public async Task<IActionResult> OnGetAccept(int id, CancellationToken cancellationToken)
        {
            CommntsList = _commentAppService.GetComments();
            var result = await _commentAppService.AcceptComment(id, cancellationToken);
            if (result.IsSuccess)
            {
                Message = result.Message;
                return RedirectToPage("index");
            }
            Message = result.Message;
            return Page();
        }
    }
}
