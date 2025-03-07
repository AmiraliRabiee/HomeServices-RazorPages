using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Services.HomeService
{
    public class SuggestionService(ISuggestionRepository _suggestionRepository) : ISuggestionService
    {
        public async Task<Result> AcceptSuggestion(int id, CancellationToken cancellationToken)
            => await _suggestionRepository.AcceptSuggestion(id, cancellationToken);
        public async Task<Result> Create(Suggestion suggestion, CancellationToken cancellationToken)
            => await _suggestionRepository.CreateSuggestion(suggestion, cancellationToken);

        public async Task<Result> Delete(Suggestion suggestion, CancellationToken cancellationToken)
            => await _suggestionRepository.DeleteSuggestion(suggestion, cancellationToken);

        public async Task<List<SummSuggestionDto>> GetAllDto(CancellationToken cancellationToken)
            => await _suggestionRepository.GetAllDto(cancellationToken);

        public int GetCount(int id)
             => _suggestionRepository.GetCount(id);

        public async Task<SummSuggestionDto> GetExpertBySuggestion(int id, CancellationToken cancellationToken)
            => await _suggestionRepository.GetExpertBySuggestion(id, cancellationToken);

        public async Task<Suggestion> GetnById(int id, CancellationToken cancellationToken)
            => await  _suggestionRepository.GetSuggestionById(id, cancellationToken);

        public async Task<SummSuggestionDto> GetSuggestionAccepted(int id, CancellationToken cancellationToken)
            => await _suggestionRepository.GetSuggestionAccepted(id, cancellationToken);

        public Task<List<SummSuggestionDto>> GetSuggestionDetails(int id, CancellationToken cancellationToken)
            => _suggestionRepository.GetSuggestionDetails(id,cancellationToken);

        public async Task<SummSuggestionDto> GetSuggestionDto(int id, CancellationToken cancellationToken)
            => await _suggestionRepository.GetSuggestionDto(id, cancellationToken);

        public async Task<List<SummSuggestionDto>> GetSuggestionSkills(CustomerDto customer, CancellationToken cancellationToken)
            => await _suggestionRepository.GetSuggestionSkills(customer, cancellationToken);

        public async Task<List<SummSuggestionDto>> GetSuggestionSkills2(CancellationToken cancellationToken)
            => await _suggestionRepository.GetSuggestionSkills2(cancellationToken);

        public async Task<float> GetSuggestPrice(int id, CancellationToken cancellationToken)
            => await _suggestionRepository.GetSuggestPrice(id , cancellationToken);

        public async Task<Result> SoftDelete(Suggestion suggestion, CancellationToken cancellationToken)
            => await _suggestionRepository.SoftDeleteSuggestion(suggestion, cancellationToken);

        public async Task<Result> Update(Suggestion suggestion, CancellationToken cancellationToken)
            => await _suggestionRepository.UpdateSuggestion(suggestion, cancellationToken);
    }
}
