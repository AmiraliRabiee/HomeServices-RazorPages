using App.Domain.AppServices.Base;
using App.Domain.AppServices.HomeService;
using App.Domain.Core.Contracts.AppService;
using HomeServices.Endpoints.WebApi.WebFramework;
using Microsoft.AspNetCore.Mvc;

namespace HomeServices.Endpoints.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WorksController : ControllerBase
    {
        private readonly string _apiKey;
        private readonly IHouseWorkAppService _houseWorkAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IOrderAppService _orderAppService;

        public WorksController(IConfiguration configuration,
            IHouseWorkAppService houseWorkAppService,
            ICategoryAppService categoryAppService
            ,IOrderAppService orderAppService)
        {
            _apiKey = configuration["ApiSettings:ApiKey"];
            _houseWorkAppService = houseWorkAppService;
            _categoryAppService = categoryAppService;
            _orderAppService = orderAppService;
        }

        [HttpGet("GetCategoryWithServices")]
        public async Task<IActionResult> GetWorks([FromHeader(Name = "API-Key")] string apiKey, CancellationToken cancellationToken)
        {
            try
            {
                var categoryIds = await _categoryAppService.GetCategoryNumbersAsync(cancellationToken);
                if (categoryIds == null || !categoryIds.Any())
                {
                    return NotFound("کتگوری یافت نشد.");
                }

                var services = await _houseWorkAppService.GetServicesByIds(categoryIds, cancellationToken);
                if (services == null || !services.Any())
                {
                    return NotFound("سرویس با این شناسه یافت نشد");
                }
                return Ok(services);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "با خطا مواجه شد.");
            }
        }

        [HttpGet("GetOrders")]
        [ServiceFilter(typeof(ApiKeyAuthenticationFilter))]
        public async Task<IActionResult> GetOrders([FromHeader(Name = "API-KEY")] string apiKey)
        {
            var orders = await _orderAppService.GetAll();
            if (orders.Count > 0)
            {
                return Ok(orders);
            }
            return BadRequest("سفارشی یافت نشد");
        }
    }
}
