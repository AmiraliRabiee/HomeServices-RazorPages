using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Infrastructure.EFCore.DataBase.Common;
using Microsoft.EntityFrameworkCore;

namespace App.InfraAccess.EFCore.DataAccess.Repositories.BaseEntities
{
    public class CityRepository(AppDbContext _appDbContext) : ICityRepository
    {
        public async Task<List<City>> GetCities(CancellationToken cancellationToken)
            => await _appDbContext.Cities.ToListAsync(cancellationToken);
    }
}
