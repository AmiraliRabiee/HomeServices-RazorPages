using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace HomeServices_RazorPage.Pages
{
    public class IndexModel(ILogger<IndexModel> _logger , ICategoryAppService _categoryAppService,IHouseWorkAppService _houseWorkAppService ) : PageModel
    {
        [BindProperty]
        public List<CategoryDto> Cats { get; set; }
        public List<SummHouseWorkDto> Works { get; set; }

        public async Task  OnGet(int id,CancellationToken cancellationToken)
        {
            var ids = new List<int> { 1, 11, 34, 42, 51, 76, 88 };
            Cats = await _categoryAppService.GetParentCategories(cancellationToken);
            Works = await _houseWorkAppService.GetFavoriteServices(ids, cancellationToken);
        }
    }
}
