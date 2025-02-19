using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entites.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPages.Pages.Categories
{
    [Authorize(Roles = "َAdmin")]
    public class IndexModel(ICategoryAppService _categoryAppService) : PageModel
    {
        public List<Category> Categories { get; set; }
        public void OnGet()
        {
            Categories = _categoryAppService.GetAll();
        }
    }
}
