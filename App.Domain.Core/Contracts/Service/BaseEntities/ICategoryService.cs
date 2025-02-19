using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.Core.Contracts.Service.BaseEntities
{
    public interface ICategoryService
    {
        Task<Result> CreateCategpry(Category category, CancellationToken cancellationToken);
        Task<Result> UpdateCategory(Category category, CancellationToken cancellationToken);
        Task<Result> DeleteCategory(Category category, CancellationToken cancellationToken);
        Task<Result> SoftDeleteComment(Category category, CancellationToken cancellationToken);
        Category GetCategory(int id);
        List<Category> GetAllCategories();
    }
}
