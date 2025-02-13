using App.Domain.Core.Entites.Result;
using App.Domain.Core.Entites;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IUserRepository
    {
        Task<Result> Create(AppUser model, CancellationToken cancellationToken);
        Task<Result> DeleteUser(AppUser user, CancellationToken cancellationToken);
        Task<Result> UpdateUser(AppUser user, CancellationToken cancellationToken);
        Task<Result> UpdateBalance(AppUser user, CancellationToken cancellationToken);
        Task<Result> ChangeStatus(AppUser user, CancellationToken cancellationToken);
    }
}
