using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Admin.Pages
{
    //[Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IDashboardAppService _dashboardAppService;


        public IndexModel(IDashboardAppService dashboardAppService)
        {
            _dashboardAppService = dashboardAppService;
        }

        [BindProperty]
        public StatisticsDataDto DashboardData { get; set; }

        public void OnGet()
        {
            var data = User;
            DashboardData = _dashboardAppService.GetStatisticsData();
        }
    }
}
