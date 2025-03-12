using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository.User;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;

namespace HomeServices_RazorPage.Areas.Customer.Pages.Menu
{
    public class ProfileModel(UserManager<AppUser> userManager 
        , IBaseDataAppService _baseDataAppService
        ,IUserAppService _userAppService
        , IUserRepository userRepository
        , IMemoryCache _cache
        , ILogger<ProfileModel> _logger) : PageModel
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
        [BindProperty]
        public AppUser ClientUser { get; set; }
        public async Task OnGet( CancellationToken cancellationToken)
        {
            if (!_cache.TryGetValue("Cities", out List<City> cities))
            {
                _logger.LogInformation("Cache miss: Fetching cities from the database.");
                cities = await _baseDataAppService.GetCitiesAsync(cancellationToken);

                _cache.Set("Cities", cities, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(7200) // Cache for 2 hours
                });
            }
            else
            {
                _logger.LogInformation("Cache hit: Retrieving cities from the cache.");
            }

            Cities = cities;
            OnlineUser = await userManager.GetUserAsync(User);
            UserDto = _userAppService.GetDtoById(OnlineUser.Id);
            CustomerDto = await _userAppService.GetCustomerById(OnlineUser.Id, cancellationToken);
            ClientUser = _userAppService.GetById(OnlineUser.Id);
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var update = await _userAppService.UpdateCustomerInformation(UserDto, cancellationToken);
            var upload = await _userAppService.UplpadingImage(UserUploadImage, ClientUser, cancellationToken);
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
