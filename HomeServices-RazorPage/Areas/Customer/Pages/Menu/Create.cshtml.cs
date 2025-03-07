using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace HomeServices_RazorPage.Areas.Customer.Pages.Menu
{
    [Authorize(Roles = "Customer")]
    public class CreateModel(IHouseWorkAppService _workAppService,ICategoryAppService _categoryAppService, IOrderAppService _orderAppService,
        UserManager<AppUser> userManager, IHouseWorkRepository houseWorkRepository) : PageModel
    {
        [BindProperty]
        public CategoryDto ThisCategory { get; set; }
        [BindProperty]
        public SummHouseWorkDto ThisWork { get; set; }
        [BindProperty]
        public SummOrderDto NewOrder { get; set; } = new SummOrderDto();
        [BindProperty]
        public AppUser OnlineUser { get; set; }
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public CategoryDto ParentCategory { get; set; }

        public async Task OnGet(int serviceId, CancellationToken cancellationToken)
        {
            ThisCategory = await houseWorkRepository.GetCategoryByServiceId(serviceId, cancellationToken);
            ParentCategory = await _categoryAppService.GetCategoryDto(ThisCategory.ParentId);            
            ThisWork = await _workAppService.GetServiceById(serviceId, cancellationToken);
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                OnlineUser = user;
                NewOrder.CustomerId = user.Id;
                NewOrder.HouseWorkId = ThisWork.Id;

            }
            else
            {
                throw new Exception("کاربر پیدا نشد");
            }
        }

        public async Task<IActionResult> OnPostCreate(CancellationToken cancellationToken)
        {

            var pc = new PersianCalendar();

            NewOrder.CompletionDate = new DateTime(NewOrder.CompletionDate.Year, NewOrder.CompletionDate.Month, NewOrder.CompletionDate.Day, pc);

            var result = await _orderAppService.CreateOrder(OnlineUser,NewOrder, cancellationToken);
            if (result.IsSuccess)
            {
                Message = result.Message;
                return RedirectToPage("myorders");
            }

            Message = result.Message;
            return Page();
        }
    }
}
