using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Services.HomeService
{
    public class OrderService(IOrderRepository _orderRepository) : IOrderService
    {

        public Task ChangeToExpertSelection(int id, CancellationToken cancellationToken)
            => _orderRepository.ChangeToExpertSelection(id, cancellationToken);

        public Task<Result> CheckIsConfrim(int id, CancellationToken cancellationToken)
            => _orderRepository.CheckIsConfrim(id, cancellationToken);

        public Task<Result> CheckIsFinish(int id, CancellationToken cancellationToken)
            => _orderRepository.CheckIsFinish(id, cancellationToken);

        public async Task<List<SummOrderDto>> GetOrdersById(int id, CancellationToken cancellationToken)
            => await _orderRepository.GetOrdersById(id, cancellationToken);

        public Task<Result> IsExistSuggestion(int id)
            => _orderRepository.IsExistSuggestion(id);

        public async Task ChangeToDone(int id, CancellationToken cancellationToken)
            => await _orderRepository.ChangeToDone(id, cancellationToken);

        public async Task ChangeToNewlyRegistered(int id, CancellationToken cancellationToken)
            =>await _orderRepository.ChangeToNewlyRegistered(id, cancellationToken);

        public async Task ChangeToWaitingForService(int id, CancellationToken cancellationToken)
            => await _orderRepository.ChangeToWaitingForService(id, cancellationToken);

        public async Task<Result> Create(SummOrderDto order, CancellationToken cancellationToken)
            => await _orderRepository.CreateOrder(order, cancellationToken);

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
            => await _orderRepository.DeleteOrder(id, cancellationToken);

        public async Task<List<SummOrderDto>> GetAll()
            => await _orderRepository.GetOrders();

        public async Task<SummOrderDto> GetOrderById(int id, CancellationToken cancellationToken)
            => await _orderRepository.GetOrderById(id, cancellationToken);

        public async Task<Result> SoftDelete(Order order, CancellationToken cancellationToken)
            => await _orderRepository.SoftDeleteOrder(order, cancellationToken);

        public async Task<Result> Update(Order order, CancellationToken cancellationToken)
            => await _orderRepository.UpdateOrder(order, cancellationToken);

        public async Task<int> GetActiveServicesCount(int id, CancellationToken cancellationToken)
            => await _orderRepository.GetActiveServicesCount(id, cancellationToken);

        public async Task<int> GetDoneServicesCount(int id, CancellationToken cancellationToken)
            => await _orderRepository.GetDoneServicesCount(id, cancellationToken);

        public async Task<List<SummOrderDto>> GetCustomerOrders(int customerId, CancellationToken cancellationToken)
            => await _orderRepository.GetCustomerOrders(customerId, cancellationToken);

        public async Task ChangeToPayment(int id, CancellationToken cancellationToken)
            => await _orderRepository.ChangeToPayment(id, cancellationToken);
    }
}
