using App.Domain.Core.Contracts.Dapper.Repository;
using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Contracts.Service.Cache;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;
using App.Domain.Core.Exceptions;

namespace App.Domain.Services.Base
{
    public class CategoryService(ICategoryRepository _categoryRepository,
        ICategoryDapperRepository _categoryDapperRepository,
        ICacheService _cacheService) : ICategoryService
    {
        public async  Task<Result> CreateCategpry(CategoryDto category, CancellationToken cancellationToken)
            => await _categoryRepository.CreateCategpry(category, cancellationToken);

        public Task<Result> DeleteCategory(int id, CancellationToken cancellationToken)
            => _categoryRepository.DeleteCategory(id, cancellationToken);

        public async Task<List<CategoryDto>> GetAllCategories(CancellationToken cancellationToken)
        {
            var cacheKey = CacheKeys.AllCategories;
            var cached = await _cacheService.GetAsync<List<CategoryDto>>(cacheKey);
            if (cached is not null)
                return cached;

            var categories = await _categoryRepository.GetAllCategories(cancellationToken);
            await _cacheService.SetAsync(cacheKey, categories, TimeSpan.FromMinutes(30));
            return categories;
        }


        public async Task<CategoryDto?> GetCategoryDto(int? id)
        {
            var categoryDto = await _categoryRepository.GetCategoryDto(id);
            if (categoryDto is null)
                throw new NotFoundException($"دسته با شناسه {id} یافت نشد.");
            return categoryDto;
        }

        public async Task<List<int>> GetCategoryNumbersAsync(CancellationToken cancellationToken)
            => await _categoryRepository.GetCategoryNumbersAsync(cancellationToken);

        public async Task<List<CategoryDto>> GetChildCategories(CancellationToken cancellationToken)
            => await _categoryDapperRepository.GetChildCategoriesAsync(cancellationToken);

        public async Task<List<Category>> GetChildCategoriesById(int id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategory(id);
            var categories = await _categoryRepository.GetChildCategoriesById(id, cancellationToken);
            if (categories is null)
                throw new NotFoundException($"زیردسته های {category.Title} یافت نشد.");
            return categories;
        }

        public async Task<int> GetChildCount(int categoryId)
            => await _categoryRepository.GetChildCount(categoryId);

        public async Task<List<CategoryDto>> GetParentCategories(CancellationToken cancellationToken)
            => await _categoryDapperRepository.GetCategoriesAsync(cancellationToken);

        public async Task<Result> SoftDeleteComment(Category category, CancellationToken cancellationToken)
            => await _categoryRepository.SoftDeleteCategory(category, cancellationToken);

        public async Task<Result> UpdateCategory(CategoryDto category, CancellationToken cancellationToken)
            => await _categoryRepository.UpdateCategory(category, cancellationToken);

        //public async Task<List<Category>> GetForSearch(string item)
        //    => await _categoryRepository.GetForSearch(item);


        //public async Task<List<CategoryDto>> GetCatyegoryByParent(int id, CancellationToken cancellationToken)
        //{
        //    var category = await _categoryRepository.GetCategory(id);
        //    var categories = await _categoryRepository.GetCatyegoryByParent((int)id, cancellationToken);
        //    if (categories is null)
        //        throw new NotFoundException($"دسته با شناسه {category.Title} یافت نشد.");
        //    return categories;
        //}

        //public async Task<Category?> GetCategory(int id)
        //    => await _categoryRepository.GetCategory(id);

        //public async Task<Category?> GetChildCategoryById(int id)
        //    => await _categoryRepository.GetChildCategoryById(id);
    }
}
