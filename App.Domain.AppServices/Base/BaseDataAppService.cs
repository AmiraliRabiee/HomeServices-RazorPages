using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Contracts.Service.User;
using App.Domain.Core.Dto.Dashboard;

namespace App.Domain.AppServices.Base
{
    public class BaseDataAppService(IBaseDataService _baseDataService,
        IOrderService _orderService,
        ICommentService _commentService ,
        IUserService _userService ,
        ISuggestionService _suggestionService,
        IExpertService _expertService,
        IHouseWorkService _houseWorkService,
        ICategoryService _categoryService) : IBaseDataAppService
    {
        public async Task<List<City>> GetCitiesAsync(CancellationToken cancellationToken)
            => await _baseDataService.GetCitiesAsync(cancellationToken);

        public async Task<StatisticsCustomerDto> GetStatisticData(int id ,CancellationToken cancellationToken)
        {
            var model = new StatisticsCustomerDto();
            model.ActiveCount =await _orderService.GetActiveServicesCount(id,cancellationToken);
            model.DoneCount = await  _orderService.GetDoneServicesCount(id,cancellationToken);
            model.CommentCount = await _commentService.GetRegisterCommentCount(id, cancellationToken);
            model.Balance = await _userService.GetBalance(id,cancellationToken);
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

        public async Task<StatisticsExpertDto> GetStatisticsExpert(int id ,CancellationToken cancellationToken)
        {
            var model = new StatisticsExpertDto();
            model.Balance = await _userService.GetBalance(id, cancellationToken);
            model.CommentsCount = await _commentService.GetAcceptCommentCount(id, cancellationToken);
            model.DoneSuggestions =await  _suggestionService.DoneSuggestionsCount(id , cancellationToken);
            model.ActiveCount = await _suggestionService.ActiveSuggestionsCount(id, cancellationToken); 

            return model;
        }

        public async Task<List<object>> Search(string item)
        {
            var result = new List<object>();

            var categories = await _categoryService.GetForSearch(item);
            var works = await _houseWorkService.GetForSearch(item);
            var experts = await _expertService.GetForSearch(item);

            result.AddRange(categories);
            result.AddRange(works);
            result.AddRange(experts);
            return result;
        }
    }
}
