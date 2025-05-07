using App.Domain.Core.Dto;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;
using App.Domain.Core.Entites.User;

namespace App.Domain.Core.Contracts.Service.User
{
    public interface IExpertService
    {
        Task CreateExpert(int userId, string? biography, string? address, CancellationToken cancellationToken);
        Task<Result> UpdateExpert(ExpertDto model, CancellationToken cancellationToken);
        Task<Result> DeleteExpert(int expertId, CancellationToken cancellationToken);
        Task<Result> SoftDeleteExpert(int expertId, CancellationToken cancellationToken);
        Task<ExpertDto> GetExpertDto(int id, CancellationToken cancellationToken);
        Task<Result> UpdateBalance(int id, float balance, CancellationToken cancellationToken);
        Task<List<ExpertWorkDto>> GetExpertSkillsNameAsync(int expertId, CancellationToken cancellationToken);

        Task<List<int>> GetExpertSkills(int expertId, CancellationToken cancellationToken);
        Task UpdateExpertSkills(int expertId, List<int> houseWorkIds, CancellationToken cancellationToken);
        Task<List<SearchResultDto>> GetForSearch(string item);
        Task<int> GetSkillUpdateCount(int expertId, CancellationToken cancellationToken);
        Task IncrementSkillUpdateCount(int expertId, CancellationToken cancellationToken);
        Task<DateTime?> GetLastSkillUpdateDate(int expertId, CancellationToken cancellationToken);
        Task UpdateLastSkillUpdateDate(int expertId, DateTime updateDate, CancellationToken cancellationToken);
        Task ResetSkillUpdateCount(int expertId, CancellationToken cancellationToken);
    }
}
