using App.Domain.Core.Entites;
using App.Domain.Core.Entites.Result;

namespace App.Domain.Core.Contracts.Repository.BaseEntities
{
    public interface ICategoryRepository
    {
        Task<Result> CreateCategpry(Category category, CancellationToken cancellationToken);
        Task<Result> UpdateCategory(Category category, CancellationToken cancellationToken);
        Task<Result> DeleteCategory(Category category, CancellationToken cancellationToken);
        Task<Result> SoftDeleteComment(Category category, CancellationToken cancellationToken);
    }
}
