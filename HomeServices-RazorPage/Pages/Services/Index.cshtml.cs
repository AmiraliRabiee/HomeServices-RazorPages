using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.HomeService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Pages.Services
{
    public class IndexModel(IHouseWorkAppService _houseWorkAppService) : PageModel
    {
        public List<SummHouseWorkDto> Works { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            Works = await _houseWorkAppService.GetAllAsync(cancellationToken);
        }
    }
}
