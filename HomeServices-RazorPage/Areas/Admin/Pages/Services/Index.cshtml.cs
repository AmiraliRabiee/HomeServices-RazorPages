using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.HomeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Admin.Pages.Services
{
    [Authorize(Roles = "Admin")]
    public class IndexModel(IHouseWorkAppService _houseWorkAppService) : PageModel
    {
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public List<SummHouseWorkDto> HouseWorks { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            HouseWorks = await _houseWorkAppService.GetAllAsync(cancellationToken);
        }

        public async Task OnGetDelete(int id, CancellationToken cancellationToken)
        {
            HouseWorks = await _houseWorkAppService.GetAllAsync(cancellationToken);
            var result = await _houseWorkAppService.DeLeteServiceAsync(id, cancellationToken);
            if (result.IsSuccess)
            {
                Message = result.Message;
            }
            Message = result.Message;
        }
    }
}
