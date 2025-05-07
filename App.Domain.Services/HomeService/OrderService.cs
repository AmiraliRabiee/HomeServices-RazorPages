using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;

namespace App.Domain.Services.HomeService
{
    public class OrderService(IOrderRepository _orderRepository) : IOrderService
    {

        public Task ChangeToExpertSelection(int id)
            => _orderRepository.ChangeToExpertSelection(id);

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

        public async Task<int> Create(SummOrderDto order, CancellationToken cancellationToken)
            => await _orderRepository.CreateOrder(order, cancellationToken);

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
            => await _orderRepository.DeleteOrder(id, cancellationToken);

        public async Task<List<SummOrderDto>> GetAll()
            => await _orderRepository.GetAll();

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

        //public Task<List<SummOrderDto>> GetReserveOrders(AppUser user, CancellationToken cancellationToken)
        //    => _orderRepository.GetReserveOrders(user, cancellationToken);

        public async Task<List<SummOrderDto>> GetOrdersAcceptExpert(Expert expert, CancellationToken cancellationToken)
            => await _orderRepository.GetOrdersAcceptExpert(expert, cancellationToken);

        public async Task<List<SummOrderDto>> GetOrdersMatchingExpert(Expert expert, CancellationToken cancellationToken)
            =>await _orderRepository.GetOrdersMatchingExpert(expert, cancellationToken);

        public async Task<Expert?> GetExpertWithSkillsAndCity(int userId, CancellationToken cancellationToken)
            => await _orderRepository.GetExpertWithSkillsAndCity(userId, cancellationToken);

        public async Task<float> GetSuggestPrice(int orderId, CancellationToken cancellationToken)
            => await _orderRepository.GetSuggestPrice(orderId, cancellationToken);
    }
}
