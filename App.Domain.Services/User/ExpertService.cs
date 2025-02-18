using App.Domain.Core.Contracts.Repository.User;
using App.Domain.Core.Contracts.Service.User;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;

namespace App.Domain.Services.User
{
    public class ExpertService(IExpertRepository _expertRepository) : IExpertService
    {
        public Task CreateExpert(int userId, string? biography, string? address, CancellationToken cancellationToken)
            => _expertRepository.CreateExpert(userId, biography, address, cancellationToken);

        public Task<Result> DeleteExpert(int expertId, CancellationToken cancellationToken)
            => _expertRepository.DeleteExpert(expertId, cancellationToken);

        public Task<Result> SoftDeleteExpert(int expertId, CancellationToken cancellationToken)
            => _expertRepository.SoftDeleteExpert(expertId, cancellationToken);

        public Task<Result> UpdateExpert(Expert model, CancellationToken cancellationToken)
            => _expertRepository.UpdateExpert(model, cancellationToken);
    }
}
