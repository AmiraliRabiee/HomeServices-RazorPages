using App.Domain.Core.Entites.Result;

namespace App.Domain.Core.Contracts.Repository.User
{
    public interface IRoleRepository
    {
        Task<Result> AssignRole(int userId, int roleId, CancellationToken cancellationToken);
    }
}
