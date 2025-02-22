using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Admin.Pages.Categories
{
    //[Authorize(Roles = "َAdmin")]
    public class IndexModel(ICategoryAppService _categoryAppService) : PageModel
    {
        [BindProperty]
        public List<Category> Categories { get; set; }

        [BindProperty]
        public CategoryDto Category { get; set; }
        [BindProperty]
        public string Message { get; set; }


        public async Task<IActionResult> OnGetDelete(int id, CancellationToken cancellationToken)
        {
            var result = await _categoryAppService.DeleteCategoryAsync(id, cancellationToken);

            if (result.IsSuccess)
            {
                TempData["Message"] = result.Message;
                return RedirectToPage("Index");
            }

            Message = result.Message;
            return Page();
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
