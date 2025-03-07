using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace HomeServices_RazorPage.Pages.SubCategories
{
    public class IndexModel(ICategoryAppService _categoryAppService, IHouseWorkAppService _houseWorkAppService) : PageModel
    {
        [BindProperty]
        public List<int> SelectedCategories { get; set; } = new List<int>();
        [BindProperty]
        public List<Category> ChildCategory { get; set; }
        [BindProperty]
        public List<Category> ParentCategories { get; set; }
        [BindProperty]
        public List<SummHouseWorkDto> Works { get; set; }
        [BindProperty]
        public List<Category> Categories { get; set; }
        [BindProperty]
        public CategoryDto CategoryDto { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 5; 

        public bool HasNextPage { get; set; }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            ParentCategories = _categoryAppService.GetParentCategories();
            CategoryDto = await _categoryAppService.GetCategoryDto(id);
            ChildCategory = _categoryAppService.GetChildCategoriesById(id);
            Categories = _categoryAppService.GetAllCategories();
            Works = await _houseWorkAppService.GetServicesById(id, cancellationToken);
        }

        public async Task OnPost(int id ,CancellationToken cancellationToken)
        {
            CategoryDto = await _categoryAppService.GetCategoryDto(id);
            ChildCategory = _categoryAppService.GetChildCategoriesById(id);
            Works = new List<SummHouseWorkDto>();

            foreach (var categoryId in SelectedCategories)
            {
                var jobs = await _houseWorkAppService.GetServicesByChildId(categoryId, cancellationToken);
                Works.AddRange(jobs);
            }
        }
    }
}
