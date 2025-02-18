using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Services.HomeService
{
    public class SuggestionService(ISuggestionRepository _suggestionRepository) : ISuggestionService
    {
        public Task<Result> Create(Suggestion suggestion, CancellationToken cancellationToken)
            => _suggestionRepository.CreateSuggestion(suggestion, cancellationToken);

        public Task<Result> Delete(Suggestion suggestion, CancellationToken cancellationToken)
            => _suggestionRepository.DeleteSuggestion(suggestion, cancellationToken);

        public Task<List<SummSuggestionDto>> GetDetails(Suggestion model, CancellationToken cancellationToken)
            => _suggestionRepository.GetSuggestionDetails(model, cancellationToken);

        public Task<Suggestion> GetnById(int id, CancellationToken cancellationToken)
            => _suggestionRepository.GetSuggestionById(id, cancellationToken);

        public Task<Result> SoftDelete(Suggestion suggestion, CancellationToken cancellationToken)
            => _suggestionRepository.SoftDeleteSuggestion(suggestion, cancellationToken);

        public Task<Result> Update(Suggestion suggestion, CancellationToken cancellationToken)
            => _suggestionRepository.UpdateSuggestion(suggestion, cancellationToken);
    }
}
