using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Dto.HomeService;

namespace App.Domain.AppServices.HomeService
{
    public class OrderAppService(IOrderService _orderService) : IOrderAppService
    {

        public async Task<List<SummOrderDto>> GetAll()
            => await _orderService.GetAll();
    }
}
