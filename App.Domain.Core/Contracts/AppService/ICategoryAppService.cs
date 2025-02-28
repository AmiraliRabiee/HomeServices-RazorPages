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
        List<Category> GetAllCategories();
        List<Category> GetParentCategories();
        List<Category> GetChildCategories();
        CategoryDto GetCategoryDto(int id);
        List<CategoryDto> GetCatyegoryByParent(int id);
        List<CategoryDto> GetCatyegor1();
        List<CategoryDto> GetCatyegor2();
        List<CategoryDto> GetCatyegor3();
        List<CategoryDto> GetCatyegor4();
        List<CategoryDto> GetCatyegor5();
        List<CategoryDto> GetCatyegor6();
    }
}
