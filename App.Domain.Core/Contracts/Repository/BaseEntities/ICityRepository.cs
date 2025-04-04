using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repository.BaseEntities
{
    public interface ICityRepository
    {
        Task<List<City>> GetCities(CancellationToken cancellationToken);
    }
}
