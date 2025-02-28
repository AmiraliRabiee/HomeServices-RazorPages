using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IOrderAppService
    {
        //Task<Result> Create(Order order, CancellationToken cancellationToken);
        //Task<Result> Delete(Order order, CancellationToken cancellationToken);
        //Task<Result> SoftDelete(Order order, CancellationToken cancellationToken);
        //Task<Result> Update(Order order, CancellationToken cancellationToken);
        //Task<Order> GetOrderById(int id, CancellationToken cancellationToken);
        Task<List<SummOrderDto>> GetAll();
        Task<Result> ChangeStatus(int id, CancellationToken cancellationToken);
        //Task ChangeToNewlyRegistered(Order model, CancellationToken cancellationToken);
        //Task ChangeToExpertSelection(Order model, CancellationToken cancellationToken);
        //Task ChangeToWaitingForService(Order model, CancellationToken cancellationToken);
        //Task ChangeToDone(Order model, CancellationToken cancellationToken);
    }
}
