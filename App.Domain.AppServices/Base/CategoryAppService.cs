using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

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

        public List<Category> GetAllCategories()
            => _categoryService.GetAllCategories();

        public Category GetCategory(int id)
            => _categoryService.GetCategory(id);

        public CategoryDto GetCategoryDto(int id)
            => _categoryService.GetCategoryDto(id);

        public List<CategoryDto> GetCatyegor1()
            => _categoryService.GetCatyegor1();

        public List<CategoryDto> GetCatyegor2()
            => _categoryService.GetCatyegor2();

        public List<CategoryDto> GetCatyegor3()
            => _categoryService.GetCatyegor3();

        public List<CategoryDto> GetCatyegor4()
            => _categoryService.GetCatyegor4();

        public List<CategoryDto> GetCatyegor5()
            => _categoryService.GetCatyegor5();

        public List<CategoryDto> GetCatyegor6()
            => _categoryService.GetCatyegor6();

        public List<CategoryDto> GetCatyegoryByParent(int id)
            => _categoryService.GetCatyegoryByParent(id);

        public List<Category> GetChildCategories()
            => _categoryService.GetChildCategories();

        public List<Category> GetParentCategories()
            => _categoryService.GetParentCategories();

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

    }
}
