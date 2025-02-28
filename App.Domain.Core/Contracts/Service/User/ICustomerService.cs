using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;

namespace App.Domain.Core.Contracts.Service.User
{
    public interface ICustomerService
    {
        Task CreateCustomer(int userId, string? address, CancellationToken cancellationToken);
        Task<Result> DeleteCustomer(int customerId, CancellationToken cancellationToken);
        Task<Result> SoftDeleteCustomer(int customerId, CancellationToken cancellationToken);
        Task<Result> UpdateCustomer(CustomerDto model, CancellationToken cancellationToken);
    }
}
