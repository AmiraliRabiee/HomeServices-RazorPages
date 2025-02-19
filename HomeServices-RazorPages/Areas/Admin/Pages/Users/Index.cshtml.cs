using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPages.Areas.Admin.Pages.Users
{
    //[Authorize(Roles = "Admin")]
    public class IndexModel(IUserAppService _userAppService) : PageModel
    {
        [BindProperty]
        public List<AppUser> Users { get; set; }

        public void OnGet()

        {
            var data = User;

            Users = _userAppService.GetAll();
        }


        [HttpGet]
        public void OnGetDelete(int id)
        {

        }
    }
}
