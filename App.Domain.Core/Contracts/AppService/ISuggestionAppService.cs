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
        Task<List<SummSuggestionDto>> GetSuggestionSkills(CustomerDto customer, CancellationToken cancellationToken);
        Task<List<SummSuggestionDto>> GetSuggestionSkills2(CancellationToken cancellationToken);
        Task<Result> Create(Suggestion suggestion, CancellationToken cancellationToken);
        Task<List<SummSuggestionDto>> CheckSuggestions(int id, CancellationToken cancellationToken);
        Task<Result> AcceptSuggestion(int id, int orderId, CancellationToken cancellationToken);
        Task<SummSuggestionDto> GetExpertBySuggestion(int id, CancellationToken cancellationToken);
        Task<SummSuggestionDto> GetSuggestionAccepted(int id, CancellationToken cancellationToken);

    }
}
