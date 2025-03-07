using App.Domain.Core.Contracts.Repository.User;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;
using App.Infrastructure.EFCore.DataBase.Common;
using Microsoft.EntityFrameworkCore;

namespace App.InfraAccess.EFCore.DataAccess.Repositories.User
{
    public class AdminRepository(AppDbContext _appDbContext) : IAdminRepository
    {
        public async Task<AppUser> GetAdmin(CancellationToken cancellationToken)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(a => a.Id == 1, cancellationToken);
        }

        public async Task<float> GetAdminBalance(CancellationToken cancellationToken)
        {
            var balance = await _appDbContext.Users
                .Where(u => u.Id == 1)
                .Select(u => u.Balance)
                .FirstOrDefaultAsync(cancellationToken);

            return balance;
        }

        public async Task<float> GetProfit(CancellationToken cancellationToken)
            => await _appDbContext.Admins
            .Select(a => a.ProfitPercentage)
            .FirstOrDefaultAsync(cancellationToken);

        public async Task<Result> UpdateBalance(float balance, CancellationToken cancellationToken)
        {
            var a = await _appDbContext.Users.FirstOrDefaultAsync(a => a.Id == 1 , cancellationToken);
            a.Balance = balance;
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new Result { IsSuccess = true };
        }
    }
}
