using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace HomeServices_RazorPage.Pages
{
    public class IndexModel(ILogger<IndexModel> _logger, ICategoryAppService _categoryAppService, IHouseWorkAppService _houseWorkAppService, IBaseDataAppService _baseDataAppService) : PageModel
    {
        [BindProperty]
        public List<CategoryDto> Cats { get; set; }
        public List<SummHouseWorkDto> Works { get; set; }
        [BindProperty]
        public string ServiceInput { get; set; }
        [BindProperty]
        public string ExpertInput { get; set; }
        [BindProperty]
        public List<SearchResultDto> SearchResults { get; set; }
        [BindProperty]
        public int SelectedId { get; set; }

        public bool IsSearchSubmitted { get; set; }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            var ids = new List<int> { 1, 11, 34, 42, 51, 76, 88 };
            Cats = await _categoryAppService.GetParentCategories(cancellationToken);
            Works = await _houseWorkAppService.GetFavoriteServices(ids, cancellationToken);
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            IsSearchSubmitted = true;

            var result = new List<SearchResultDto>();

            if (!string.IsNullOrEmpty(ServiceInput))
            {
                var houseWorkResults = await _baseDataAppService.SearchHouseWorkAndCategries(ServiceInput);
                result.AddRange(houseWorkResults);
            }

            if (!string.IsNullOrEmpty(ExpertInput))
            {
                var expertResults = await _baseDataAppService.SearchExperts(ExpertInput);
                result.AddRange(expertResults);
            }

            SearchResults = result;

            if (SelectedId > 0)
            {
                return RedirectToPage("/client/index", new { id = SelectedId });
            }

            var ids = new List<int> { 1, 11, 34, 42, 51, 76, 88 };
            Cats = await _categoryAppService.GetParentCategories(cancellationToken);
            Works = await _houseWorkAppService.GetFavoriteServices(ids, cancellationToken);

            return Page();
        }
    }
}