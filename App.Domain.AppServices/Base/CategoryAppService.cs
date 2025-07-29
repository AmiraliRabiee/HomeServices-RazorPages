using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;
using App.Domain.Core.Exceptions;

namespace App.Domain.AppServices.Base
{
    public class CategoryAppService(ICategoryService _categoryService, IDataService _dataService) : ICategoryAppService
    {
        public async Task<Result> AddCategpryAsync(CategoryDto category, CancellationToken cancellationToken)
        {
            if (category.CategoryImage is not null)
            {
                category.ImagePath = await _dataService.UploadImage(category.CategoryImage!, "Profiles", cancellationToken);
                var result = await _categoryService.CreateCategpry(category, cancellationToken);
                if (result.IsSuccess)
                    return new Result { IsSuccess = true, Message = result.Message };
            }
            return new Result { IsSuccess = false, Message = "با خطا مواجه شد" };
        }

        public async Task<Result> DeleteCategoryAsync(int id, CancellationToken cancellationToken)
            => await _categoryService.DeleteCategory(id, cancellationToken);

        public async Task<List<CategoryDto>> GetAllCategories(CancellationToken cancellationToken)
            => await _categoryService.GetAllCategories(cancellationToken);

        public async Task<CategoryDto> GetCategoryDto(int? id)
        {
            var categoryDto = await _categoryService.GetCategoryDto(id);
            return categoryDto;
        }

        public async Task<List<int>> GetCategoryNumbersAsync(CancellationToken cancellationToken)
            => await _categoryService.GetCategoryNumbersAsync(cancellationToken);

        public async Task<List<CategoryDto>> GetChildCategories(CancellationToken cancellationToken)
            => await _categoryService.GetChildCategories(cancellationToken);

        public async Task<List<Category>> GetChildCategoriesById(int id, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetChildCategoriesById(id, cancellationToken);
            return categories;
        }

        public async Task<List<CategoryDto>> GetParentCategories(CancellationToken cancellationToken)
            => await _categoryService.GetParentCategories(cancellationToken);

        public async Task<Result> SoftDeleteCategoryAsync(Category category, CancellationToken cancellationToken)
            => await _categoryService.SoftDeleteComment(category, cancellationToken);

        public async Task<Result> UpdateCategoryAsync(CategoryDto category, CancellationToken cancellationToken)
        {
            if (category.CategoryImage is not null)
            {
                category.ImagePath = await _dataService.UploadImage(category.CategoryImage!, "Profiles", cancellationToken);
                var result = await _categoryService.UpdateCategory(category, cancellationToken);
                if (result.IsSuccess)
                    return new Result { IsSuccess = true, Message = result.Message };
            }
            return new Result { IsSuccess = false, Message = "با خطا مواجه شد" };
        }

        //public async Task<List<CategoryDto>> GetCatyegoryByParent(int id, CancellationToken cancellationToken)
        //{
        //    var categories = await _categoryService.GetCatyegoryByParent(id, cancellationToken);
        //    return categories;
        //}

        //public async Task<Category?> GetCategory(int id)
        //{
        //    var category = await _categoryService.GetCategory(id);
        //    if (category is null)
        //        throw new NotFoundException($"دسته با شناسه {id} یافت نشد.");
        //    return category;
        //}

        //public async Task<int> GetChildCount(int categoryId)
        //    => await _categoryService.GetChildCount(categoryId);
    }
}
