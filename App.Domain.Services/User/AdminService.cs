using App.Domain.Core.Contracts.Repository.User;
using App.Domain.Core.Contracts.Service.User;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;

namespace App.Domain.Services.User
{
    public class AdminService(IAdminRepository _adminRepository) : IAdminService
    {
        public async Task<AppUser> GetAdmin(CancellationToken cancellationToken)
            => await _adminRepository.GetAdmin(cancellationToken);

        public async Task<float> GetAdminBalance(CancellationToken cancellationToken)
            => await _adminRepository.GetAdminBalance(cancellationToken);

        public async Task<float> GetProfit(CancellationToken cancellationToken)
            => await _adminRepository.GetProfit(cancellationToken);

        public async  Task<Result> UpdateBalance(float balance, CancellationToken cancellationToken)
            => await _adminRepository.UpdateBalance(balance, cancellationToken);
    }
}
