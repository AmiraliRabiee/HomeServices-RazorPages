using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace HomeServices_RazorPage.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel(IUserAppService _userAppService) : PageModel
    {
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public UserDto UserDto { get; set; }

        [BindProperty]
        public AppUser CurrentUser { get; set; }

        [BindProperty]
        public List<UserDto> Users { get; set; }

        public async Task<IActionResult> OnGet(CancellationToken cancellationToken)
        {
            var data = User;

            Users = await _userAppService.GetAll(cancellationToken);
            return Page();
        }


        public async Task OnGetAccept(int id,CancellationToken cancellationToken)
        {
            Users = await _userAppService.GetAll(cancellationToken);
            await _userAppService.AcceptUserAsync(id);
        }


        public async Task OnGetReject(int id, CancellationToken cancellationToken)
        {
            Users = await _userAppService.GetAll(cancellationToken);
            await _userAppService.RejectUserAsync(id);
        }
        //public async Task OnGetDelete(int id,CancellationToken cancellationToken)
        //{
        //    Users = await _userAppService.GetAll(cancellationToken);
        //    var result = await _userAppService.RemoveUser(id, cancellationToken);
        //    if (result.IsSuccess)
        //    {
        //        Message = result.Message;
        //    }
        //    Message = result.Message;
        //}

    }
}
