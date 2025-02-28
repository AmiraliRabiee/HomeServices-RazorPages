using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Admin.Pages.Categories
{
    [Authorize(Roles = "Admin")]
    public class CreateModel(ICategoryAppService _categoryAppService) : PageModel
    {
        [BindProperty]
        public List<Category> ExistCategories { get; set; }
        [BindProperty]
        public CategoryDto Category { get; set; }
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public bool IsSuccess { get; set; }

        public void OnGet()
        {
            ExistCategories = _categoryAppService.GetParentCategories();
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var result = await _categoryAppService.AddCategpryAsync(Category, cancellationToken);
            if (result.IsSuccess)
            {
                Message = result.Message;
                return Page();
            }
            Message = result.Message;
            return Page();
        }
    }
}
