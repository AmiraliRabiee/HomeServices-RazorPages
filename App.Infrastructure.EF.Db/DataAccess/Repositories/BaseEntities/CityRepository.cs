using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Infrastructure.DataBase.EFCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore.DataAccess.Repositories.BaseEntities
{
    public class CityRepository(AppDbContext _appDbContext) : ICityRepository
    {
        public List<City> GetCities()
            =>  _appDbContext.Cities.ToList();
    }
}
