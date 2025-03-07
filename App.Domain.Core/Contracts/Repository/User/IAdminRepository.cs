using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;

namespace App.Domain.Core.Contracts.Repository.User
{
    public interface IAdminRepository
    {
        Task<float> GetProfit(CancellationToken cancellationToken);
        Task<float> GetAdminBalance(CancellationToken cancellationToken);
        Task<Result> UpdateBalance(float balance ,CancellationToken cancellationToken);
        Task<AppUser> GetAdmin(CancellationToken cancellationToken);
    }
}
