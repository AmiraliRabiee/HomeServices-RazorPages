using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Core.Contracts.Service.HomeServices
{
    public interface IOrderService
    {
        Task<Result> Create(Order order, CancellationToken cancellationToken);
        Task<Result> Delete(Order order, CancellationToken cancellationToken);
        Task<Result> SoftDelete(Order order, CancellationToken cancellationToken);
        Task<Result> Update(Order order, CancellationToken cancellationToken);
        Task<Order> GetOrderById(int id, CancellationToken cancellationToken);
        Task<List<SummOrderDto>> GetAll();
        Task ChangeToNewlyRegistered(Order model, CancellationToken cancellationToken);
        Task ChangeToExpertSelection(Order model, CancellationToken cancellationToken);
        Task ChangeToWaitingForService(Order model, CancellationToken cancellationToken);
        Task ChangeToDone(Order model, CancellationToken cancellationToken);
    }
}
