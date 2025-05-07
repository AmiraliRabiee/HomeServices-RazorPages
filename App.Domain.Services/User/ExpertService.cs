using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Contracts.Repository.User;
using App.Domain.Core.Contracts.Service.User;
using App.Domain.Core.Dto;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;
using App.Domain.Core.Entites.User;

namespace App.Domain.Services.User
{
    public class ExpertService(IExpertRepository _expertRepository, IExpertHouseWorkRepository _expertHouseWorkRepository) : IExpertService
    {
        public Task CreateExpert(int userId, string? biography, string? address, CancellationToken cancellationToken)
            => _expertRepository.CreateExpert(userId, biography, address, cancellationToken);

        public Task<Result> DeleteExpert(int expertId, CancellationToken cancellationToken)
            => _expertRepository.DeleteExpert(expertId, cancellationToken);

        public async Task<ExpertDto> GetExpertDto(int id, CancellationToken cancellationToken)
            => await _expertRepository.GetExpertDto(id, cancellationToken);

        public async Task<List<int>> GetExpertSkills(int expertId, CancellationToken cancellationToken)
            => await _expertHouseWorkRepository.GetExpertSkillsAsync(expertId, cancellationToken);

        public async Task<List<ExpertWorkDto>> GetExpertSkillsNameAsync(int expertId, CancellationToken cancellationToken)
            => await _expertHouseWorkRepository.GetExpertSkillsNameAsync(expertId, cancellationToken);

        public async Task<List<SearchResultDto>> GetForSearch(string item)
            => await _expertRepository.GetForSearch(item);

        public async Task<DateTime?> GetLastSkillUpdateDate(int expertId, CancellationToken cancellationToken)
            => await _expertRepository.GetLastSkillUpdateDate(expertId, cancellationToken);

        public async Task<int> GetSkillUpdateCount(int expertId, CancellationToken cancellationToken)
            => await _expertRepository.GetSkillUpdateCount(expertId, cancellationToken);

        public async Task IncrementSkillUpdateCount(int expertId, CancellationToken cancellationToken)
            => await _expertRepository.IncrementSkillUpdateCount(expertId, cancellationToken);

        public async Task ResetSkillUpdateCount(int expertId, CancellationToken cancellationToken)
            => await _expertRepository.ResetSkillUpdateCount(expertId, cancellationToken);

        public Task<Result> SoftDeleteExpert(int expertId, CancellationToken cancellationToken)
            => _expertRepository.SoftDeleteExpert(expertId, cancellationToken);

        public async Task<Result> UpdateBalance(int id, float balance, CancellationToken cancellationToken)
            => await _expertRepository.UpdateBalance(id, balance, cancellationToken);

        public async Task<Result> UpdateExpert(ExpertDto model, CancellationToken cancellationToken)
            =>await _expertRepository.UpdateExpert(model, cancellationToken);

        public async Task UpdateExpertSkills(int expertId, List<int> houseWorkIds, CancellationToken cancellationToken)
            => await _expertHouseWorkRepository.UpdateExpertSkillsAsync(expertId, houseWorkIds, cancellationToken);

        public async Task UpdateLastSkillUpdateDate(int expertId, DateTime updateDate, CancellationToken cancellationToken)
            => await _expertRepository.UpdateLastSkillUpdateDate(expertId, updateDate, cancellationToken);
    }
}
