using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;
using App.Domain.Core.Entites.User;

namespace App.Domain.Core.Contracts.Repository.HomeServices
{
    public interface IOrderRepository
    {
        Task<int> CreateOrder(SummOrderDto order, CancellationToken cancellationToken);
        Task<Result> DeleteOrder(int id, CancellationToken cancellationToken);
        Task<Result> SoftDeleteOrder(Order order, CancellationToken cancellationToken);
        Task<Result> UpdateOrder(Order order, CancellationToken cancellationToken);
        Task<SummOrderDto> GetOrderById(int id, CancellationToken cancellationToken);
        Task<List<SummOrderDto>> GetAll();
        Task ChangeToNewlyRegistered(int id, CancellationToken cancellationToken);
        Task ChangeToExpertSelection(int id);
        Task ChangeToWaitingForService(int id, CancellationToken cancellationToken);
        Task ChangeToDone(int id, CancellationToken cancellationToken);
        Task ChangeToPayment(int id, CancellationToken cancellationToken);
        Task<Result> IsExistSuggestion(int id);
        Task<List<SummOrderDto>> GetOrdersById(int id, CancellationToken cancellationToken);
        Task<int> GetActiveServicesCount(int id, CancellationToken cancellationToken);
        Task<int> GetDoneServicesCount(int id, CancellationToken cancellationToken);
        Task<List<SummOrderDto>> GetCustomerOrders(int customerId, CancellationToken cancellationToken);
        Task<float> GetSuggestPrice(int orderId, CancellationToken cancellationToken);
        Task<Expert?> GetExpertWithSkillsAndCity(int userId, CancellationToken cancellationToken);
        Task<List<SummOrderDto>> GetOrdersAcceptExpert(Expert expert, CancellationToken cancellationToken);
        Task<List<SummOrderDto>> GetOrdersMatchingExpert(Expert expert, CancellationToken cancellationToken);
    }
}
