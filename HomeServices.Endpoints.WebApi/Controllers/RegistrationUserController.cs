using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;

namespace HomeServices.Endpoints.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationUserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly string _apiKey;

        public RegistrationUserController(IUserAppService userAppService, IConfiguration configuration)
        {
            _userAppService = userAppService;
            _apiKey = configuration["ApiSettings:ApiKey"];
        }

        [HttpPost("register-customer/expert")]
        public async Task<IActionResult> Register([FromHeader(Name = "API-Key")] string apiKey,
            [FromBody] CreateUserDto model, CancellationToken cancellationToken)
        {
            if (apiKey != _apiKey)
            {
                return Unauthorized("Invalid API Key.");
            }

            if (model == null)
            {
                return BadRequest("Invalid model data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userAppService.Register(model, cancellationToken);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }
    }
}