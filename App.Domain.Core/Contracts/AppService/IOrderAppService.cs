using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IOrderAppService
    {
        Task<int> GetActiveServicesCount(int id, CancellationToken cancellationToken);
        Task<int> GetDoneServicesCount(int id, CancellationToken cancellationToken);
        Task<List<SummOrderDto>> GetAll();
        Task<Result> ChangeStatus(int id, CancellationToken cancellationToken);
        Task ChangeToPayment(int id, CancellationToken cancellationToken);
        Task<Result> CreateOrder(AppUser user, SummOrderDto order, CancellationToken cancellationToken);
        Task<List<SummOrderDto>> GetOrdersById(int id, CancellationToken cancellationToken);
        Task<SummOrderDto> GetOrderById(int id, CancellationToken cancellationToken);
        Task<List<SummOrderDto>> GetCustomerOrders(int customerId, CancellationToken cancellationToken);
        Task<Result> Delete(int id, CancellationToken cancellationToken);

    }
}
