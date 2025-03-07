using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Core.Contracts.Service.HomeServices
{
    public interface IOrderService
    {
        Task<Result> Create(SummOrderDto order, CancellationToken cancellationToken);
        Task<Result> Delete(int id, CancellationToken cancellationToken);
        Task<Result> SoftDelete(Order order, CancellationToken cancellationToken);
        Task<Result> Update(Order order, CancellationToken cancellationToken);
        Task<SummOrderDto> GetOrderById(int id, CancellationToken cancellationToken);
        Task<List<SummOrderDto>> GetAll();
        Task ChangeToNewlyRegistered(int id, CancellationToken cancellationToken);
        Task ChangeToExpertSelection(int id, CancellationToken cancellationToken);
        Task ChangeToWaitingForService(int id, CancellationToken cancellationToken);
        Task ChangeToDone(int id, CancellationToken cancellationToken);
        Task ChangeToPayment(int id, CancellationToken cancellationToken);
        Task<Result> CheckIsConfrim(int id, CancellationToken cancellationToken);
        Task<Result> CheckIsFinish(int id, CancellationToken cancellationToken);
        Task<Result> IsExistSuggestion(int id);
        Task<List<SummOrderDto>> GetOrdersById(int id, CancellationToken cancellationToken);
        Task<int> GetActiveServicesCount(int id, CancellationToken cancellationToken);
        Task<int> GetDoneServicesCount(int id, CancellationToken cancellationToken);
        Task<List<SummOrderDto>> GetCustomerOrders(int customerId, CancellationToken cancellationToken);
    }
}
