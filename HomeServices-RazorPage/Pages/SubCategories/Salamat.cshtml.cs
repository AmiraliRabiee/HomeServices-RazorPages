using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Pages.SubCategories
{
    public class SalamatModel(ICategoryAppService _categoryAppService) : PageModel
    {
        public List<CategoryDto> CatDtos { get; set; }
        [BindProperty]
        public List<Category> Cats { get; set; }
        public void OnGet(int id)
        {
            Cats = _categoryAppService.GetParentCategories();
            CatDtos = _categoryAppService.GetCatyegoryByParent(id);
        }
    }
}
