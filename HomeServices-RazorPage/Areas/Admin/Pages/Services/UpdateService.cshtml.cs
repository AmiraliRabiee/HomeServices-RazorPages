using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Admin.Pages.Services
{
    [Authorize(Roles = "Admin")]
    public class UpdateServiceModel(IHouseWorkAppService _workAppService, ICategoryAppService _categoryAppService) : PageModel
    {
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public UpdateHouseWork Work { get; set; } = new UpdateHouseWork();
        [BindProperty]
        public List<Category> ChildCategories { get; set; }
        [BindProperty]
        public HouseWork ExistWork { get; set; }


        public async Task OnGet(int id)
        {
            ChildCategories = _categoryAppService.GetChildCategories();
            ExistWork = _workAppService.GetByIdAsync(id);
            Work = _workAppService.GetServiceDto(id); 
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            ChildCategories = _categoryAppService.GetChildCategories();

            var result = await _workAppService.UpdateServiceAsync(Work, cancellationToken);
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
