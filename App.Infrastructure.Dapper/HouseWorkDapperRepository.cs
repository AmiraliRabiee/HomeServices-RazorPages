using Dapper;
using System.Data;
using App.Domain.Core.Dto.HomeService;
using App.Infrastructure.Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class HouseWorkDapperRepository : IHouseWorkDapperRepository
    {
        private readonly string connectionString;

        public HouseWorkDapperRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<SummHouseWorkDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var works = await connection.QueryAsync<SummHouseWorkDto>(HomeServiceQueries.GetHouseWorks,cancellationToken);
                return works.ToList();
            }
        }
    }
}
