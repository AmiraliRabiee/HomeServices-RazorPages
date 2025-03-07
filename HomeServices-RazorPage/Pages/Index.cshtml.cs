using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entites.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Pages
{
    public class IndexModel(ILogger<IndexModel> _logger , ICategoryAppService _categoryAppService) : PageModel
    {
        [BindProperty]
        public List<Category> Cats { get; set; }

        public async void OnGet(int id)
        {
            Cats = _categoryAppService.GetParentCategories();
        }
    }
}
