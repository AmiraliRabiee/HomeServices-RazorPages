using App.Domain.Core.Dto.Dashboard;
using System.Threading;

namespace App.Domain.Core.Contracts.Dapper.Repository
{
    public interface ICategoryDapperRepository
    {
        Task<List<CategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken);
        Task<List<CategoryDto>> GetChildCategoriesAsync(CancellationToken cancellationToken);
    }
}
