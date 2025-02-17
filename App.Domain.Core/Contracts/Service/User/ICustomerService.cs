using App.Domain.Core.Entites.Result;

namespace App.Domain.Core.Contracts.Service.UserService
{
    public interface ICustomerService
    {
        Task CreateCustomer(int userId, string? address, CancellationToken cancellationToken);
        Task<Result> DeleteCustomer(int customerId, CancellationToken cancellationToken);
        Task<Result> SoftDeleteCustomer(int customerId, CancellationToken cancellationToken);
    }
}
