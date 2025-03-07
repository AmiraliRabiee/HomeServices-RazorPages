using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Contracts.Service.User;
using App.Domain.Core.Dto.Dashboard;

namespace App.Domain.AppServices.Base
{
    public class BaseDataAppService(IBaseDataService _baseDataService, IOrderService _orderService
        ,ICommentService _commentService , IUserService userService , ISuggestionService _suggestionService) : IBaseDataAppService
    {
        public List<City> GetCities()
            => _baseDataService.GetCities();

        public async Task<StatisticsCustomerDto> GetStatisticData(int id ,CancellationToken cancellationToken)
        {
            var model = new StatisticsCustomerDto();
            model.ActiveCount =await _orderService.GetActiveServicesCount(id,cancellationToken);
            model.DoneCount = await  _orderService.GetDoneServicesCount(id,cancellationToken);
            model.CommentCount = await _commentService.GetRegisterCommentCount(id, cancellationToken);
            model.Balance = await userService.GetCustomerBalance(id,cancellationToken);
            return model;
        }

        public async Task<AmountsDto> GetAmountsData(int id, CancellationToken cancellationToken)
        {
            var model = new AmountsDto();
            model.SuggestPrice = await _suggestionService.GetSuggestPrice(id, cancellationToken);
            model.Profit = model.SuggestPrice * 0.06f;
            model.TotalSum =model.SuggestPrice;

            return model;
        }
    }
}
