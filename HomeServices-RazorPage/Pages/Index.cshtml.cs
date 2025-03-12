using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace HomeServices_RazorPage.Pages
{
    public class IndexModel(ILogger<IndexModel> _logger , ICategoryAppService _categoryAppService ) : PageModel
    {
        [BindProperty]
        public List<CategoryDto> Cats { get; set; }

        public async Task  OnGet(int id,CancellationToken cancellationToken)
        {
            Cats = await _categoryAppService.GetParentCategories(cancellationToken);
        }
    }
}
