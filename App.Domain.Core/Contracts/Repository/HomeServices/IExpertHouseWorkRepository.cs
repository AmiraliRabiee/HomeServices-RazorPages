using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.Service;

namespace App.Domain.Core.Contracts.Repository.HomeServices
{
    public interface IExpertHouseWorkRepository
    {
        Task<List<int>> GetExpertSkillsAsync(int expertId, CancellationToken cancellationToken);
        Task<List<ExpertWorkDto>> GetExpertSkillsNameAsync(int expertId, CancellationToken cancellationToken);
        Task UpdateExpertSkillsAsync(int expertId, List<int> houseWorkIds, CancellationToken cancellationToken);
    }

}
