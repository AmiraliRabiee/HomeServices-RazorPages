
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace App.Infrastructure.Dapper
{
    public class CityDapperRepository : ICityDapperRepository
    {
        private readonly string connectionString;

        public CityDapperRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<List<City>> GetCitiesAsync(CancellationToken cancellationToken)
        {
            using(IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var cities = await dbConnection.QueryAsync<City>(HomeServiceQueries.GetCities, cancellationToken);
                return cities.ToList();
            }
        }
    }
}
