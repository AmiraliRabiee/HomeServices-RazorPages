using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.Services.Base
{
    public class CategoryService(ICategoryRepository _categoryRepository) : ICategoryService
    {
        public Task<Result> CreateCategpry(Category category, CancellationToken cancellationToken)
            => _categoryRepository.CreateCategpry(category, cancellationToken);

        public Task<Result> DeleteCategory(Category category, CancellationToken cancellationToken)
            => _categoryRepository.DeleteCategory(category, cancellationToken);

        public Task<Result> SoftDeleteComment(Category category, CancellationToken cancellationToken)
            => _categoryRepository.SoftDeleteCategory(category, cancellationToken);

        public Task<Result> UpdateCategory(Category category, CancellationToken cancellationToken)
            => _categoryRepository.UpdateCategory(category, cancellationToken);
    }
}
