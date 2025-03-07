using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Pages.Categories
{
    public class IndexModel(ICategoryAppService _categoryAppService , IHouseWorkAppService _houseWorkAppService) : PageModel
    {
        [BindProperty]
        public List<CategoryDto> CatDtos { get; set; }
        [BindProperty]
        public List<Category> Cats { get; set; }
        public async void OnGet(int id)
        {
            Cats = _categoryAppService.GetParentCategories();
            CatDtos = _categoryAppService.GetCatyegoryByParent(id);
        }
    }
}
