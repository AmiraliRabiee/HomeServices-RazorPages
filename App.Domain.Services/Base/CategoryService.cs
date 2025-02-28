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

        public List<CategoryDto> GetCatyegor1()
            => _categoryRepository.GetCatyegor1();

        public List<CategoryDto> GetCatyegor2()
            => _categoryRepository.GetCatyegor2();

        public List<CategoryDto> GetCatyegor3()
            => _categoryRepository.GetCatyegor3();

        public List<CategoryDto> GetCatyegor4()
            => _categoryRepository.GetCatyegor4();

        public List<CategoryDto> GetCatyegor5()
            => _categoryRepository.GetCatyegor5();

        public List<CategoryDto> GetCatyegor6()
            => _categoryRepository.GetCatyegor6();

        public List<CategoryDto> GetCatyegoryByParent(int id)
            => _categoryRepository.GetCatyegoryByParent((int)id);
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
