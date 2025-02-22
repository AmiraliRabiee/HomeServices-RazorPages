using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.Core.Contracts.Service.BaseEntities
{
    public interface ICategoryService
    {
        Task<Result> CreateCategpry(CategoryDto category, CancellationToken cancellationToken);
        Task<Result> UpdateCategory(CategoryDto category, CancellationToken cancellationToken);
        Task<Result> DeleteCategory(int id, CancellationToken cancellationToken);
        Task<Result> SoftDeleteComment(Category category, CancellationToken cancellationToken);
        Category GetCategory(int id);
        List<Category> GetAllCategories();
        List<Category> GetParentCategories();
        List<Category> GetChildCategories();
        CategoryDto GetCategoryDto(int id);
    }
}
