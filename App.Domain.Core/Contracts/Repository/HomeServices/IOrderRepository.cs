using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Core.Contracts.Repository.HomeServices
{
    public interface IOrderRepository
    {
        Task<Result> CreateOrder(Order order, CancellationToken cancellationToken);
        Task<Result> DeleteOrder(Order order, CancellationToken cancellationToken);
        Task<Result> SoftDeleteOrder(Order order, CancellationToken cancellationToken);
        Task<Result> UpdateOrder(Order order, CancellationToken cancellationToken);
        Task<Order> GetOrderById(int id, CancellationToken cancellationToken);
        Task<List<SummOrderDto>> GetOrders();
        Task ChangeToNewlyRegistered(Order model, CancellationToken cancellationToken);
        Task ChangeToExpertSelection(Order model, CancellationToken cancellationToken);
        Task ChangeToWaitingForService(Order model, CancellationToken cancellationToken);
        Task ChangeToDone(Order model, CancellationToken cancellationToken);
    }
}
