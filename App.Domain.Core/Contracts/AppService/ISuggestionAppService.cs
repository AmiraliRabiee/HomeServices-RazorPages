using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Core.Contracts.AppService
{
    public interface ISuggestionAppService
    {
        Task<SummSuggestionDto> GetSuggestionDto(int id, CancellationToken cancellationToken);
        Task<List<SummSuggestionDto>> GetAll(CancellationToken cancellationToken);
        Task<List<SummSuggestionDto>> GetSuggestionDetails(int id, CancellationToken cancellationToken);
        Task<Result> Create(Suggestion suggestion, float basePrice, CancellationToken cancellationToken);
        Task<List<SummSuggestionDto>> CheckSuggestions(int id, CancellationToken cancellationToken);
        Task<Result> AcceptSuggestion(int id, int orderId, CancellationToken cancellationToken);
        Task<SummSuggestionDto> GetExpertBySuggestion(int id, CancellationToken cancellationToken);
        Task<SummSuggestionDto> GetSuggestionAccepted(int id, CancellationToken cancellationToken);
        Task<int> ActiveSuggestionsCount(int expertId, CancellationToken cancellationToken);
        Task<List<SummSuggestionDto>> DoneSuggestions(int expertId, CancellationToken cancellationToken);
        Task<List<SummSuggestionDto>> ActiveSuggestions(int expertId, CancellationToken cancellationToken);
        Task<int> DoneSuggestionsCount(int expertId, CancellationToken cancellationToken);
        Task<Suggestion?> GetLastSuggestion(int expertId, int orderId, CancellationToken cancellationToken);
        Task<ExpertDto> GetExpertDto(int id, CancellationToken cancellationToken);
    }
}
