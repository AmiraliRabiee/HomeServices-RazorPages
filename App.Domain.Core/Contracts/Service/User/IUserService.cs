using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.Result;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Entites;

namespace App.Domain.Core.Contracts.Service
{
    public interface IUserService
    {
        Task<Result> DeleteUser(AppUser user, CancellationToken cancellationToken);
        Task<Result> SoftDeleteUser(AppUser user, CancellationToken cancellationToken);
        Task<Result> UpdateUser(AppUser user, CancellationToken cancellationToken);
        Task<Result> UpdateBalance(AppUser user, CancellationToken cancellationToken);
        Task<Result> ChangeStatus(AppUser user, CancellationToken cancellationToken);
        Task<UserDto> GetUserDetails(int id, CancellationToken cancellationToken);
        Task<List<Customer>> GetAllCustomers();
        Task<List<Expert>> GetAllExperts();
    }
}
