using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.Core.Contracts.AppService
{
    public interface ICategoryAppService
    {
        Task<Result> AddCategpryAsync(CategoryDto category, CancellationToken cancellationToken);
        Task<Result> UpdateCategoryAsync(CategoryDto category, CancellationToken cancellationToken);
        Task<Result> DeleteCategoryAsync(int id, CancellationToken cancellationToken);
        Task<Result> SoftDeleteCategoryAsync(Category category, CancellationToken cancellationToken);
        Category GetCategory(int id);
        List<CategoryDto> GetAllCategories();
        Task<List<CategoryDto>> GetParentCategories(CancellationToken cancellationToken);
        Task<List<CategoryDto>> GetChildCategories(CancellationToken cancellationToken);
        Task<CategoryDto> GetCategoryDto(int? id);
        Task<List<CategoryDto>> GetCatyegoryByParent(int id,CancellationToken cancellationToken);
        Task<int> GetChildCount(int categoryId);
        Task<List<Category>> GetChildCategoriesById(int id,CancellationToken cancellationToken);
        Task<List<int>> GetCategoryNumbersAsync(CancellationToken cancellationToken);
    }
}
