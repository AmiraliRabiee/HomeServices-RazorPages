using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Expert.Pages.Menu
{
    [Authorize(Roles = "Expert")]
    public class OrdersModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
