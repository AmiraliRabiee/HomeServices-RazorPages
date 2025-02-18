using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Core.Contracts.Service.HomeServices
{
    public interface ISuggestionService
    {
        Task<Result> Create(Suggestion suggestion, CancellationToken cancellationToken);
        Task<Result> Delete(Suggestion suggestion, CancellationToken cancellationToken);
        Task<Result> SoftDelete(Suggestion suggestion, CancellationToken cancellationToken);
        Task<Result> Update(Suggestion suggestion, CancellationToken cancellationToken);
        Task<Suggestion> GetnById(int id, CancellationToken cancellationToken);
        Task<List<SummSuggestionDto>> GetDetails(Suggestion model, CancellationToken cancellationToken);
    }
}
