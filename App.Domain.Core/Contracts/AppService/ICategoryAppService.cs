using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.Core.Contracts.AppService
{
    public interface ICategoryAppService
    {
        Task<Result> AddCategpryAsync(Category category, CancellationToken cancellationToken);
        Task<Result> UpdateCategoryAsync(Category category, CancellationToken cancellationToken);
        Task<Result> DeleteCategoryAsync(Category category, CancellationToken cancellationToken);
        Task<Result> SoftDeleteCategoryAsync(Category category, CancellationToken cancellationToken);
        Category GetCategory(int id);
        List<Category> GetAllCategories();
    }
}
