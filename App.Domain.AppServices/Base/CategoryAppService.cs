using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.AppServices.HomeService
{
    public class CategoryAppService(ICategoryService _categoryService) : ICategoryAppService
    {
        public async Task<Result> AddCategpryAsync(Category category, CancellationToken cancellationToken)
            => await _categoryService.CreateCategpry(category, cancellationToken);

        public async  Task<Result> DeleteCategoryAsync(Category category, CancellationToken cancellationToken)
            => await _categoryService.DeleteCategory(category, cancellationToken);

        public List<Category> GetAllCategories()
            => _categoryService.GetAllCategories();

        public Category GetCategory(int id)
            => _categoryService.GetCategory(id);

        public async Task<Result> SoftDeleteCategoryAsync(Category category, CancellationToken cancellationToken)
            => await _categoryService.SoftDeleteComment(category, cancellationToken);

        public async Task<Result> UpdateCategoryAsync(Category category, CancellationToken cancellationToken)
            => await _categoryService.UpdateCategory(category, cancellationToken);
    }
}
