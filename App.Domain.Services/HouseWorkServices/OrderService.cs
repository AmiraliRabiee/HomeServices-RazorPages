using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.Result;

namespace App.Domain.Services.HouseWorkServices
{
    public class OrderService(IOrderRepository _orderRepository) : IOrderService
    {

        public Task ChangeToExpertSelection(Order model, CancellationToken cancellationToken)
            => _orderRepository.ChangeToExpertSelection (model, cancellationToken);

        Task IOrderService.ChangeToDone(Order model, CancellationToken cancellationToken)
            => _orderRepository.ChangeToDone (model, cancellationToken);

        Task IOrderService.ChangeToNewlyRegistered(Order model, CancellationToken cancellationToken)
            => _orderRepository.ChangeToNewlyRegistered(model, cancellationToken);

        Task IOrderService.ChangeToWaitingForService(Order model, CancellationToken cancellationToken) 
            => _orderRepository.ChangeToWaitingForService(model, cancellationToken);

        Task<Result> IOrderService.Create(Order order, CancellationToken cancellationToken) 
            => _orderRepository.CreateOrder(order, cancellationToken);

        Task<Result> IOrderService.Delete(Order order, CancellationToken cancellationToken)
            =>_orderRepository.DeleteOrder(order, cancellationToken);

        Task<List<SummOrderDto>> IOrderService.GetAll()
            =>_orderRepository.GetOrders();

        Task<Order> IOrderService.GetOrderById(int id, CancellationToken cancellationToken)
            =>_orderRepository.GetOrderById (id, cancellationToken);

        Task<List<Order>> IOrderService.GetOrdersForExpert(Order model, CancellationToken cancellationToken)
            => _orderRepository.GetOrdersForExpert (model, cancellationToken);

        Task<Result> IOrderService.SoftDelete(Order order, CancellationToken cancellationToken)
            => _orderRepository.SoftDeleteOrder(order, cancellationToken);

        Task<Result> IOrderService.Update(Order order, CancellationToken cancellationToken)
            =>_orderRepository.UpdateOrder(order, cancellationToken);
    }
}
