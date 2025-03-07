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
        Task<CategoryDto> GetCategoryDto(int? id);
        List<CategoryDto> GetCatyegoryByParent(int id);
        Task<int> GetChildCount(int categoryId);
        List<Category> GetChildCategoriesById(int id);
    }
}
