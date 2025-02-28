using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;

namespace App.Domain.Core.Contracts.Repository.User
{
    public interface IExpertRepository
    {
        Task CreateExpert(int userId, string? biography, string? address, CancellationToken cancellationToken);
        Task<Result> UpdateExpert(Expert model, CancellationToken cancellationToken);
        Task<Result> DeleteExpert(int expertId, CancellationToken cancellationToken);
        Task<Result> SoftDeleteExpert(int expertId, CancellationToken cancellationToken);
    }
}
