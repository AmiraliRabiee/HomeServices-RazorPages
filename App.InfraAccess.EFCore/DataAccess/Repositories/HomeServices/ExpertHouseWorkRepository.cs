using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Entites.Service;
using App.Infrastructure.EFCore.DataBase.Common;
using Microsoft.EntityFrameworkCore;

namespace App.InfraAccess.EFCore.DataAccess.Repositories.HomeServices
{
    public class ExpertHouseWorkRepository(AppDbContext _appDbContext) : IExpertHouseWorkRepository
    {

        public async Task<List<int>> GetExpertSkillsAsync(int expertId, CancellationToken cancellationToken)
        {
            return await _appDbContext.ExpertHouseWorks
                .Where(eh => eh.ExpertId == expertId)
                .Select(eh => eh.HouseWorkId)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateExpertSkillsAsync(int expertId, List<int> houseWorkIds, CancellationToken cancellationToken)
        {
            var existingSkills = await GetExistingSkillsAsync(expertId, cancellationToken);

            await RemoveUnwantedSkillsAsync(existingSkills, houseWorkIds, cancellationToken);
            await AddNewSkillsAsync(expertId, existingSkills, houseWorkIds, cancellationToken);

            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        private async Task<List<ExpertHouseWork>> GetExistingSkillsAsync(int expertId, CancellationToken cancellationToken)
        {
            return await _appDbContext.ExpertHouseWorks
                .Where(ehw => ehw.ExpertId == expertId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        private async Task RemoveUnwantedSkillsAsync(List<ExpertHouseWork> existingSkills, List<int> newHouseWorkIds, CancellationToken cancellationToken)
        {
            var skillsToRemove = existingSkills.Where(ehw => !newHouseWorkIds.Contains(ehw.HouseWorkId)).ToList();

            if (skillsToRemove.Any())
            {
                _appDbContext.ExpertHouseWorks.RemoveRange(skillsToRemove);
            }
        }

        private async Task AddNewSkillsAsync(int expertId, List<ExpertHouseWork> existingSkills, List<int> newHouseWorkIds, CancellationToken cancellationToken)
        {
            var existingHouseWorkIds = existingSkills.Select(ehw => ehw.HouseWorkId).ToHashSet();

            var newSkills = newHouseWorkIds
                .Where(hwId => !existingHouseWorkIds.Contains(hwId))
                .Select(hwId => new ExpertHouseWork
                {
                    ExpertId = expertId,
                    HouseWorkId = hwId
                })
                .ToList();

            if (newSkills.Any())
            {
                await _appDbContext.ExpertHouseWorks.AddRangeAsync(newSkills, cancellationToken);
            }
        }

    }
}