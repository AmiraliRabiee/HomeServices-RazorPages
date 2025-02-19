using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPages.Areas.Admin.Pages.Users
{
    public class UpdateModel(IUserAppService _userAppService) : PageModel
    {
        [BindProperty]
        public UserDto User { get; set; }

        //public void OnGet(int id)
        //{
        //    User = _userAppService.GetById(id);
        //}

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            await _userAppService.UpdateInformation(User, cancellationToken);
            return RedirectToPage("Index");

        }
    }
}
