﻿using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.Core.Contracts.Repository.BaseEntities
{
    public interface ICategoryRepository
    {
        Task<Result> CreateCategpry(CategoryDto category, CancellationToken cancellationToken);
        Task<Result> UpdateCategory(CategoryDto category, CancellationToken cancellationToken);
        Task<Result> DeleteCategory(int id, CancellationToken cancellationToken);
        Task<Result> SoftDeleteCategory(Category category, CancellationToken cancellationToken);
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
