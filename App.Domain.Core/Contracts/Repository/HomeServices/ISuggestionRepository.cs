using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Core.Contracts.Repository.HomeServices
{
    public interface ISuggestionRepository
    {
        Task<Result> CreateSuggestion(Suggestion suggestion, CancellationToken cancellationToken);
        Task<Result> DeleteSuggestion(Suggestion suggestion, CancellationToken cancellationToken);
        Task<Result> SoftDeleteSuggestion(Suggestion suggestion, CancellationToken cancellationToken);
        Task<Result> UpdateSuggestion(Suggestion suggestion, CancellationToken cancellationToken);
        Task<Suggestion> GetSuggestionById(int id, CancellationToken cancellationToken);
        Task<List<SummSuggestionDto>> GetSuggestionDetails(int id, CancellationToken cancellationToken);
        Task<SummSuggestionDto> GetSuggestionDto(int id, CancellationToken cancellationToken);
        Task<List<SummSuggestionDto>> GetAllDto(CancellationToken cancellationToken);
        int GetCount(int id);
        Task<List<SummSuggestionDto>> GetSuggestionSkills(CustomerDto customer, CancellationToken cancellationToken);
        Task<List<SummSuggestionDto>> GetSuggestionSkills2(CancellationToken cancellationToken);
        Task<ExpertDto> GetExpertDto(int id, CancellationToken cancellationToken);
        Task<float> GetSuggestPrice(int id, CancellationToken cancellationToken);
        Task<Result> AcceptSuggestion(int id, CancellationToken cancellationToken);
        Task<ExpertDto> GetExpertName(int id, CancellationToken cancellationToken);
        Task<SummSuggestionDto> GetExpertBySuggestion(int id, CancellationToken cancellationToken);
        Task<SummSuggestionDto> GetSuggestionAccepted(int id, CancellationToken cancellationToken);
    }
}
