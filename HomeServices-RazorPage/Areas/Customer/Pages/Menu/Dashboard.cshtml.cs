using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.HomeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Customer.Pages.Menu
{
    [Authorize(Roles = "Customer")]
    public class DashboardModel(IHouseWorkAppService _houseWorkAppService) : PageModel
    {
        [BindProperty]
        public List<SummHouseWorkDto> HouseWorks { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            HouseWorks = await _houseWorkAppService.GetAllAsync(cancellationToken);
        }
    }
}
