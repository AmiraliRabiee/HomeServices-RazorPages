using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public List<AppUser> Users { get; set; }

        public IActionResult OnGet()
        {
            var data = User;

            Users = _userAppService.GetAll();
            return Page();
        }


        public async Task OnGetDelete(int id,CancellationToken cancellationToken)
        {
            Users = _userAppService.GetAll();
            var result = await _userAppService.RemoveUser(id, cancellationToken);
            if (result.IsSuccess)
            {
                Message = result.Message;
            }
            Message = result.Message;
        }

    }
}
