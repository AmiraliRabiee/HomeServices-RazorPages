using App.Domain.AppServices.HomeService;
using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Contracts.Service.User;
using App.Domain.Core.Dto;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;
using App.Domain.Core.Entites.User;

namespace App.Domain.AppServices.Base
{
    public class BaseDataAppService(IBaseDataService _baseDataService,
        IOrderService _orderService,
        ICommentService _commentService ,
        IUserService _userService ,
        ISuggestionService _suggestionService,
        IExpertService _expertService,
        IHouseWorkService _houseWorkService,
        ICategoryService _categoryService
        ,IAdminService _adminService) : IBaseDataAppService
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
            var percent = await _adminService.GetProfit(cancellationToken);
            var model = new AmountsDto();
            model.SuggestPrice = await _suggestionService.GetSuggestPrice(id, cancellationToken);
            model.Profit = model.SuggestPrice * percent;
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

        public async Task<List<SearchResultDto>> SearchExperts(string item)
        {
            var result = new List<SearchResultDto>();
            var experts = await _expertService.GetForSearch(item);

            result.AddRange(experts);
            return result;
        }

        public async Task<List<SearchResultDto>> SearchHouseWorkAndCategries(string item)
        {
            var result = new List<SearchResultDto>();

            var works = await _houseWorkService.GetForSearch(item);
            result.AddRange(works);
            return result;
        }
        public async Task<List<string?>> GetImagesPath(int orderId)
            => await _baseDataService.GetImagesPath(orderId);

    }
}
