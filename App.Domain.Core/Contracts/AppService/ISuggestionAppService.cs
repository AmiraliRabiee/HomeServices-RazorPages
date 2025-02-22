using App.Domain.Core.Dto.HomeService;

namespace App.Domain.Core.Contracts.AppService
{
    public interface ISuggestionAppService
    {
        Task<SummSuggestionDto> GetSuggestionDto(int id, CancellationToken cancellationToken);
        Task<List<SummSuggestionDto>> GetAll(CancellationToken cancellationToken);
        Task<List<SummSuggestionDto>> GetSuggestionDetails(int id, CancellationToken cancellationToken);

    }
}
