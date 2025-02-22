using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.Services.Base
{
    public class CategoryService(ICategoryRepository _categoryRepository) : ICategoryService
    {
        public Task<Result> CreateCategpry(CategoryDto category, CancellationToken cancellationToken)
            => _categoryRepository.CreateCategpry(category, cancellationToken);

        public Task<Result> DeleteCategory(int id, CancellationToken cancellationToken)
            => _categoryRepository.DeleteCategory(id, cancellationToken);

        public List<Category> GetAllCategories()
            => _categoryRepository.GetAllCategories();

        public Category GetCategory(int id)
            => _categoryRepository.GetCategory(id);

        public CategoryDto GetCategoryDto(int id)
            => _categoryRepository.GetCategoryDto(id);

        public List<Category> GetChildCategories()
            => _categoryRepository.GetChildCategories();

        public List<Category> GetParentCategories()
            => _categoryRepository.GetParentCategories();

        public Task<Result> SoftDeleteComment(Category category, CancellationToken cancellationToken)
            => _categoryRepository.SoftDeleteCategory(category, cancellationToken);

        public Task<Result> UpdateCategory(CategoryDto category, CancellationToken cancellationToken)
            => _categoryRepository.UpdateCategory(category, cancellationToken);


    }
}
