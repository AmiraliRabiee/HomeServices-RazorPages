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

        Task IOrderService.ChangeToDone(int id, CancellationToken cancellationToken)
            => _orderRepository.ChangeToDone(id, cancellationToken);

        Task IOrderService.ChangeToNewlyRegistered(int id, CancellationToken cancellationToken)
            => _orderRepository.ChangeToNewlyRegistered(id, cancellationToken);

        Task IOrderService.ChangeToWaitingForService(int id, CancellationToken cancellationToken)
            => _orderRepository.ChangeToWaitingForService(id, cancellationToken);

        Task<Result> IOrderService.Create(Order order, CancellationToken cancellationToken)
            => _orderRepository.CreateOrder(order, cancellationToken);

        Task<Result> IOrderService.Delete(Order order, CancellationToken cancellationToken)
            => _orderRepository.DeleteOrder(order, cancellationToken);

        Task<List<SummOrderDto>> IOrderService.GetAll()
            => _orderRepository.GetOrders();

        Task<Order> IOrderService.GetOrderById(int id, CancellationToken cancellationToken)
            => _orderRepository.GetOrderById(id, cancellationToken);

        Task<Result> IOrderService.SoftDelete(Order order, CancellationToken cancellationToken)
            => _orderRepository.SoftDeleteOrder(order, cancellationToken);

        Task<Result> IOrderService.Update(Order order, CancellationToken cancellationToken)
            => _orderRepository.UpdateOrder(order, cancellationToken);
    }
}
