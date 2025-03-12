using App.Domain.Core.Entites.Service;

namespace App.Domain.Core.Contracts.Repository.HomeServices
{
    public interface IExpertHouseWorkRepository
    {
        Task<List<int>> GetExpertSkillsAsync(int expertId, CancellationToken cancellationToken);
        //Task AddNewSkillsAsync(int expertId, List<ExpertHouseWork> existingSkills, List<int> newHouseWorkIds, CancellationToken cancellationToken);
        //Task RemoveUnwantedSkillsAsync(List<ExpertHouseWork> existingSkills, List<int> newHouseWorkIds, CancellationToken cancellationToken);
        //Task<List<ExpertHouseWork>> GetExistingSkillsAsync(int expertId, CancellationToken cancellationToken);
        Task UpdateExpertSkillsAsync(int expertId, List<int> houseWorkIds, CancellationToken cancellationToken);
    }

}
