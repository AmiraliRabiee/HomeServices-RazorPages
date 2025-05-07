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
        public List<CategoryDto> ExistCategories { get; set; }
        [BindProperty]
        public CategoryDto Category { get; set; }
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public bool IsSuccess { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            ExistCategories =await _categoryAppService.GetParentCategories(cancellationToken);
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var result = await _categoryAppService.AddCategpryAsync(Category, cancellationToken);
            if (result.IsSuccess)
            {
                Message = result.Message;
                TempData["Message"] = Message;
                return RedirectToPage("/categories/index");
            }
            Message = result.Message;
            return Page();
        }
    }
}
