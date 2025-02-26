using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;
using App.Infrastructure.EFCore.DataBase.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace App.InfraAccess.EFCore.DataAccess.Repositories.BaseEntities
{
    public class CategoryRepository(AppDbContext _appDbContext) : ICategoryRepository
    {
        public async Task<Result> CreateCategpry(CategoryDto category, CancellationToken cancellationToken)
        {
            try
            {
                var newCategory = new Category();
                newCategory.Title = category.Title;
                newCategory.ParentId = category.ParentId;
                newCategory.ImagePath = category.ImagePath;

                if (category.ImagePath != null)
                    newCategory.ImagePath = category.ImagePath;

                var res = await _appDbContext.Categories.AddAsync(newCategory, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "با موفقیت افزوده شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> UpdateCategory(CategoryDto category, CancellationToken cancellationToken)
        {
            //For Admin
            try
            {
                var current = await _appDbContext.Categories
                .FirstOrDefaultAsync(c => c.Id == category.Id, cancellationToken);

                if (current is null)
                    return new Result { IsSuccess = false, Message = ".نظری با این شناسه یافت نشد" };

                current.ImagePath = category.ImagePath;
                current.Title = category.Title;
                current.ParentId = category.ParentId;


                await _appDbContext.SaveChangesAsync(cancellationToken);
                return new Result { IsSuccess = true, Message = ".به روزرسانی انجام شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> DeleteCategory(int id, CancellationToken cancellationToken)
        {
            //For Admin 
            var current = await _appDbContext.Categories
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (current is null)
                return new Result { IsSuccess = false, Message = ".نظری با این شناسه یافت نشد" };

            _appDbContext.Categories.Remove(current);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new Result { IsSuccess = true, Message = ".با موفقیت حذف شد" };
        }

        public async Task<Result> SoftDeleteCategory(Category category, CancellationToken cancellationToken)
        {
            //For Admin 
            var current = await _appDbContext.Categories
                .FirstOrDefaultAsync(c => c.Id == category.Id, cancellationToken);

            if (current is null)
                return new Result { IsSuccess = false, Message = ".نظری با این شناسه یافت نشد" };

            category.IsDeleted = true;
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new Result { IsSuccess = true, Message = ".با موفقیت حذف شد" };
        }

        public Category GetCategory(int id)
        {
            var category = _appDbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category is null)
                throw new Exception("دسته بندی ها خالی میباشد");
            return category;
        }

        public List<Category> GetAllCategories()
        {
            var categories = _appDbContext.Categories.ToList();
            if (categories is null)
                throw new Exception("دسته بندی ها خالی میباشد");
            return categories;
        }

        public List<Category> GetParentCategories()
        {
            var categories = _appDbContext.Categories
                .Where(c => c.ParentId == null).ToList();
            if (categories is null)
                throw new Exception("دسته بندی ها خالی میباشد");
            return categories;
        }

        public List<Category> GetChildCategories()
        {
            var categories = _appDbContext.Categories
                .Where(c => c.ParentId != null).ToList();
            if (categories is null)
                throw new Exception("دسته بندی ها خالی میباشد");
            return categories;
        }

        public CategoryDto GetCategoryDto(int id)
        {
            var category = _appDbContext.Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    ParentId = c.ParentId,
                    ImagePath = c.ImagePath
                })
                .FirstOrDefault();

            if (category is null)
                throw new Exception("دسته بندی یافت نشد");

            return category;
        }

    }
}