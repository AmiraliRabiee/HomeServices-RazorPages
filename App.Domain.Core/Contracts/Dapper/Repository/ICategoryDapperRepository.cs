using App.Domain.Core.Dto.Dashboard;
using System.Threading;

namespace App.Infrastructure.Dapper
{
    public interface ICategoryDapperRepository
    {
        Task<List<CategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken);
        Task<List<CategoryDto>> GetChildCategoriesAsync(CancellationToken cancellationToken);
    }
}
