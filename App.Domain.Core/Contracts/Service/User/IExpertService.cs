using App.Domain.Core.Entites.Result;
using App.Domain.Core.Entites;

namespace App.Domain.Core.Contracts.Service.UserService
{
    public interface IExpertService
    {
        Task CreateExpert(int userId, string? biography, string? address, CancellationToken cancellationToken);
        Task<Result> UpdateExpert(Expert model, CancellationToken cancellationToken);
        Task<Result> DeleteExpert(int expertId, CancellationToken cancellationToken);
        Task<Result> SoftDeleteExpert(int expertId, CancellationToken cancellationToken);
    }
}
