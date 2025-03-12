using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Dto.HomeService;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace App.Infrastructure.Dapper
{
    public class CategoryDapperRepository : ICategoryDapperRepository
    {
        private readonly string connectionString;

        public CategoryDapperRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var categories = await connection.QueryAsync<CategoryDto>(HomeServiceQueries.GetParentCategories,cancellationToken);
                return categories.ToList();
            }
        }

        public async Task<List<CategoryDto>> GetChildCategoriesAsync(CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var categories =await connection.QueryAsync<CategoryDto>(HomeServiceQueries.GetCategories,cancellationToken);
                return categories.ToList();
            }
        }
    }
}
