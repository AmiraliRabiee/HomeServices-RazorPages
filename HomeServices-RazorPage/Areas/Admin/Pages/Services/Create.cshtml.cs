using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Admin.Pages.Services
{
    public class CreateModel(IHouseWorkAppService _houseWorkAppService, ICategoryAppService _categoryAppService) : PageModel
    {
        [BindProperty]
        public SummHouseWorkDto Work { get; set; } = new SummHouseWorkDto();
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public List<Category> ChildCategories { get; set; }
        public void OnGet()
        {
            ChildCategories = _categoryAppService.GetChildCategories();
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var result = await _houseWorkAppService.AddServiceAsync(Work, cancellationToken);
            if (result.IsSuccess)
            {
                Message = result.Message;
                return RedirectToPage("Index");
            }
            Message = result.Message;
            return Page(); 
        }
    }
}
