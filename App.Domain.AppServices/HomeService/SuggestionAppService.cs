using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Dto.HomeService;

namespace App.Domain.AppServices.HomeService
{
    public class SuggestionAppService(ISuggestionService _suggestionService) : ISuggestionAppService
    {
        public async Task<List<SummSuggestionDto>> GetAll(CancellationToken cancellationToken)
        {
           var suggestions =  await _suggestionService.GetAllDto(cancellationToken);
            if (suggestions is null)
                throw new Exception("سفارشی وجود ندارد");
            return suggestions;
        }

        public Task<List<SummSuggestionDto>> GetSuggestionDetails(int id, CancellationToken cancellationToken)
            => _suggestionService.GetSuggestionDetails(id, cancellationToken);

        public Task<SummSuggestionDto> GetSuggestionDto(int id, CancellationToken cancellationToken)
            => _suggestionService.GetSuggestionDto(id, cancellationToken);


    }
}
