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
        Task ChangeToNewlyRegistered(int id, CancellationToken cancellationToken);
        Task ChangeToExpertSelection(int id, CancellationToken cancellationToken);
        Task ChangeToWaitingForService(int id, CancellationToken cancellationToken);
        Task ChangeToDone(int id, CancellationToken cancellationToken);
        Task<Result> CheckIsConfrim(int id, CancellationToken cancellationToken);
        Task<Result> CheckIsFinish(int id, CancellationToken cancellationToken);
    }
}
