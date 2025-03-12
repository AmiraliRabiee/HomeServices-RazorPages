using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Areas.Customer.Pages.Menu
{
    public class ContentModel(IUserAppService _userAppService) : PageModel
    {
        [BindProperty]
        public CustomerDto CustomerDto { get; set; }
        public async Task OnGetAsync(int customerId ,CancellationToken cancellationToken)
        {
            CustomerDto =  await _userAppService.GetCustomerById(customerId, cancellationToken);
        }
    }
}
