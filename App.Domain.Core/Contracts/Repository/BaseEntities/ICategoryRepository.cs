using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.Core.Contracts.Repository.BaseEntities
{
    public interface ICategoryRepository
    {
        Task<Result> CreateCategpry(Category category, CancellationToken cancellationToken);
        Task<Result> UpdateCategory(Category category, CancellationToken cancellationToken);
        Task<Result> DeleteCategory(Category category, CancellationToken cancellationToken);
        Task<Result> SoftDeleteCategory(Category category, CancellationToken cancellationToken);
    }
}
