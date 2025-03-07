using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository.User;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace HomeServices_RazorPage.Areas.Customer.Pages.Menu
{
    [Authorize(Roles = "Customer")]
    public class ProfileModel(UserManager<AppUser> userManager 
        , IBaseDataAppService _baseDataAppService,IUserAppService _userAppService, IUserRepository userRepository) : PageModel
    {
        [BindProperty]
        public AppUser OnlineUser { get; set; }
        [BindProperty]
        public List<City> Cities { get; set; }
        [BindProperty]
        public UserDto UserDto { get; set; }
        [BindProperty]
        public CustomerDto CustomerDto { get; set; }
        [BindProperty]
        public UpdateUser UserUploadImage { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public async Task OnGet( CancellationToken cancellationToken)
        
        {
            Cities = _baseDataAppService.GetCities();
            OnlineUser = await userManager.GetUserAsync(User);
            UserDto = _userAppService.GetDtoById(OnlineUser.Id);
            CustomerDto = await _userAppService.GetCustomerById(OnlineUser.Id, cancellationToken);

        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var update = await _userAppService.UpdateCustomerInformation(UserDto, cancellationToken);
            var upload = await _userAppService.CustomerUplpadingImage(UserUploadImage,UserDto, cancellationToken);
            var result = await _userAppService.UpdateCustomer(CustomerDto, cancellationToken);
            if (result.IsSuccess)
            {
                Message = result.Message;
                return RedirectToPage("Profile");
            }
            Message = result.Message;
            return Page();
        }
    }
}
