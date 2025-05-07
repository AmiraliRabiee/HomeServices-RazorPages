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
        List<CategoryDto> GetAllCategories();
        Task<List<CategoryDto>> GetParentCategories(CancellationToken cancellationToken);
        Task<List<CategoryDto>> GetChildCategories(CancellationToken cancellationToken);
        Task<CategoryDto> GetCategoryDto(int? id);
        Task<List<CategoryDto>> GetCatyegoryByParent(int id,CancellationToken cancellationToken);
        Task<int> GetChildCount(int categoryId);
        Task<List<Category>> GetChildCategoriesById(int id,CancellationToken cancellationToken);
        Task<List<int>> GetCategoryNumbersAsync(CancellationToken cancellationToken);
        Task<Category> GetChildCategoryById(int id);
        Task<List<Category>> GetForSearch(string item);
    }
}
