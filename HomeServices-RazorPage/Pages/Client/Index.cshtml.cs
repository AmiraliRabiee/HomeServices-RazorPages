using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Pages.Client
{
    public class IndexModel(ICategoryAppService _categoryAppService, IHouseWorkAppService _houseWorkAppService) : PageModel
    {
        [BindProperty]
        public SummHouseWorkDto Work { get; set; }
        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            Work = await _houseWorkAppService.GetServiceByChildId(id, cancellationToken);
        }
    }
}
