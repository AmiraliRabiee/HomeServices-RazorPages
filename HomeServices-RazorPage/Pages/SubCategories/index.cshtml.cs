using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Dto.HomeService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Pages.SubCategories
{
    public class IndexModel(ICategoryAppService _categoryAppService , IHouseWorkAppService _houseWorkAppService) : PageModel
    {
        [BindProperty]
        public List<SummHouseWorkDto> Works { get; set; }
        [BindProperty]
        public List<CategoryDto> CategoriesDto { get; set; }

        public void OnGet(int id)
        {
            CategoriesDto = _categoryAppService.GetCatyegor5();
            Works = _houseWorkAppService.GetServicesById();
        }
    }
}
