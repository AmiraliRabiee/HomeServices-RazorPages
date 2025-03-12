using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;
using App.Infrastructure.Dapper;

namespace App.Domain.Services.Base
{
    public class CategoryService(ICategoryRepository _categoryRepository,ICategoryDapperRepository _categoryDapperRepository) : ICategoryService
    {
        public Task<Result> CreateCategpry(CategoryDto category, CancellationToken cancellationToken)
            => _categoryRepository.CreateCategpry(category, cancellationToken);

        public Task<Result> DeleteCategory(int id, CancellationToken cancellationToken)
            => _categoryRepository.DeleteCategory(id, cancellationToken);

        public List<Category> GetAllCategories()
            => _categoryRepository.GetAllCategories();

        public Category GetCategory(int id)
            => _categoryRepository.GetCategory(id);

        public async Task<CategoryDto> GetCategoryDto(int? id)
            => await _categoryRepository.GetCategoryDto(id);

        public List<CategoryDto> GetCatyegoryByParent(int id)
            => _categoryRepository.GetCatyegoryByParent((int)id);
        public async Task<List<CategoryDto>> GetChildCategories(CancellationToken cancellationToken)
            => await _categoryDapperRepository.GetChildCategoriesAsync(cancellationToken);

        public List<Category> GetChildCategoriesById(int id)
            => _categoryRepository.GetChildCategoriesById(id);

        public async Task<int> GetChildCount(int categoryId)
            =>await _categoryRepository.GetChildCount(categoryId);
        public async Task<List<CategoryDto>> GetParentCategories(CancellationToken cancellationToken)
            => await _categoryDapperRepository.GetCategoriesAsync(cancellationToken);

        public Task<Result> SoftDeleteComment(Category category, CancellationToken cancellationToken)
            => _categoryRepository.SoftDeleteCategory(category, cancellationToken);

        public Task<Result> UpdateCategory(CategoryDto category, CancellationToken cancellationToken)
            => _categoryRepository.UpdateCategory(category, cancellationToken);


    }
}
