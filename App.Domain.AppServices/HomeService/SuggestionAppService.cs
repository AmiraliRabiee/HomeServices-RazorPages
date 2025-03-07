using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.AppServices.HomeService
{
    public class SuggestionAppService(ISuggestionService _suggestionService, IOrderService _orderService) : ISuggestionAppService
    {
        public async Task<Result> AcceptSuggestion(int id,int orderId , CancellationToken cancellationToken)
        {
            if(id == 0)
                return new Result { IsSuccess  = false , Message = "شناسه پیشنهاد یافت نشد"};
            var result = await _suggestionService.AcceptSuggestion(id, cancellationToken);
            await _orderService.ChangeToWaitingForService(orderId, cancellationToken);

            if (result.IsSuccess)
                return new Result { IsSuccess = true ,Message = result.Message };
            return new Result { IsSuccess = false ,Message = result.Message };
        }

        public async Task<Result> Create(Suggestion suggestion, CancellationToken cancellationToken)
        {
            if (suggestion is null)
                return new Result { IsSuccess = false, Message = "پیشنهادی برای ثبت وجود ندارد" };
            var result = await _suggestionService.Create(suggestion, cancellationToken);
            if (result.IsSuccess)
                return new Result { IsSuccess = true, Message = result.Message };
            return new Result { Message = result.Message };
        }



        public async Task<List<SummSuggestionDto>> GetAll(CancellationToken cancellationToken)
        {
           var suggestions =  await _suggestionService.GetAllDto(cancellationToken);
            if (suggestions is null)
                throw new Exception("سفارشی وجود ندارد");
            return suggestions;
        }

        public async Task<SummSuggestionDto> GetExpertBySuggestion(int id, CancellationToken cancellationToken)
            =>await  _suggestionService.GetExpertBySuggestion(id, cancellationToken);

        public async Task<List<SummSuggestionDto>> CheckSuggestions(int id, CancellationToken cancellationToken)
        {
            var suggestions = await  _suggestionService.GetSuggestionDetails(id, cancellationToken);
            foreach(var item in suggestions)
            {
                if(item.IsAccepted == true)
                {
                    var suggestion = await _suggestionService.GetSuggestionAccepted(id, cancellationToken);
                    suggestions.Clear();
                    suggestions.Add(suggestion);
                    return suggestions;
                }
            }
            return suggestions;
        }

        public async Task<SummSuggestionDto> GetSuggestionAccepted(int id, CancellationToken cancellationToken)
            => await _suggestionService.GetSuggestionAccepted(id, cancellationToken);

        public Task<List<SummSuggestionDto>> GetSuggestionDetails(int id, CancellationToken cancellationToken)
            => _suggestionService.GetSuggestionDetails(id, cancellationToken);

        public Task<SummSuggestionDto> GetSuggestionDto(int id, CancellationToken cancellationToken)
            => _suggestionService.GetSuggestionDto(id, cancellationToken);

        public async Task<List<SummSuggestionDto>> GetSuggestionSkills(CustomerDto customer, CancellationToken cancellationToken)
            => await _suggestionService.GetSuggestionSkills(customer, cancellationToken);

        public async Task<List<SummSuggestionDto>> GetSuggestionSkills2(CancellationToken cancellationToken)
            => await _suggestionService.GetSuggestionSkills2(cancellationToken);


    }
}
