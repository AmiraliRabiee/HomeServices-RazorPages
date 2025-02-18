using App.Domain.Core.Contracts.Repository.User;
using App.Domain.Core.Contracts.Service.User;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;

namespace App.Domain.Services.User
{
    public class CustomerService(ICustomerRepository _customerRepository) : ICustomerService
    {
        public Task CreateCustomer(int userId, string? address, CancellationToken cancellationToken)
            => _customerRepository.CreateCustomer(userId, address, cancellationToken);

        public Task<Result> DeleteCustomer(int customerId, CancellationToken cancellationToken)
            => _customerRepository.DeleteCustomer(customerId, cancellationToken);

        public Task<Result> SoftDeleteCustomer(int customerId, CancellationToken cancellationToken)
            => _customerRepository.SoftDeleteCustomer(customerId, cancellationToken);

        public Task<Result> UpdateCustomer(Customer model, CancellationToken cancellationToken)
            => _customerRepository.UpdateCustomer(model, cancellationToken);
    }
}
