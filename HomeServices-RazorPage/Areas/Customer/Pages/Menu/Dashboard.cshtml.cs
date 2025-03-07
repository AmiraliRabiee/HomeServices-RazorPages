using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Helpers;
using HomeServices_RazorPage.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Customer.Pages.Menu
{
    [Authorize(Roles = "Customer")]
    public class DashboardModel(IBaseDataAppService _baseDataAppService ,IOrderAppService _orderAppService,ISuggestionRepository suggestionRepository) : PageModel
    {
        [BindProperty]
        public StatisticsCustomerDto Data { get; set; }
        [BindProperty]
        public List<SummOrderDto> CustomerOrders { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {

            var customerId = UserTools.GetCustomerId(User.Claims);

            //var khar = await suggestionRepository.GetExpertName(customerId,cancellationToken);

            Data = await _baseDataAppService.GetStatisticData(customerId, cancellationToken);
            CustomerOrders = await _orderAppService.GetCustomerOrders(customerId, cancellationToken);

            if(CustomerOrders is null)
                TempData["ErrorMessage"] = "هنوز سفارشی ثبت نشده است";
        }
    }
}
