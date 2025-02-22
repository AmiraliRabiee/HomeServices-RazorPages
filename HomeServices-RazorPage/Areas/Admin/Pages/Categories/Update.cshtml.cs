using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Admin.Pages.Categories
{
    public class UpdateModel(ICategoryAppService _categoryAppService) : PageModel
    {
        [BindProperty]
        public Category ExistCategory { get; set; }
        [BindProperty]
        public CategoryDto Category { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public void OnGet(int id)
        {
            ExistCategory = _categoryAppService.GetCategory(id);
            Category = _categoryAppService.GetCategoryDto(id);
        }

        public async Task<IActionResult> OnPostUpdate(CancellationToken cancellationToken)
        {
            var result = await _categoryAppService.UpdateCategoryAsync(Category, cancellationToken);
            if (result.IsSuccess)
            {
                Message = result.Message;
                return RedirectToPage("/Categories/Index");
            }
            Message = result.Message;
            return Page();
        }
    }
}
