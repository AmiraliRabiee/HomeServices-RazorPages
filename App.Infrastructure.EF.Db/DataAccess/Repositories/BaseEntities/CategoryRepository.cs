using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Entites;
using App.Domain.Core.Entites.Result;
using App.Domain.Core.Enums;
using App.Infrastructure.DataBase.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace App.Infrastructure.EFCore.DataAccess.Repositories.BaseEntities
{
    public class CategoryRepository(AppDbContext _appDbContext) : ICategoryRepository
    {
        public async Task<Result> CreateCategpry(Category category ,CancellationToken cancellationToken)
        {
            try
            {
                var newCategory = new Category();
                newCategory.Title = category.Title;
                newCategory.ImagePath = category.ImagePath;
                newCategory.ParentId = category.ParentId;


                await _appDbContext.Categories.AddAsync(newCategory, cancellationToken);
                await _appDbContext.SaveChangesAsync();

                return new Result { IsSuccess = true, Message = "با موفقیت افزوده شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> UpdateCategory(Category category, CancellationToken cancellationToken)
        {
            //For Admin
            try
            {
                var current = await _appDbContext.Categories
                .FirstOrDefaultAsync(c => c.Id == category.Id, cancellationToken);

                if (current is null)
                    return new Result { IsSuccess = false, Message = ".نظری با این شناسه یافت نشد" };

                var newComment = new Comment();
                newComment.CreateAt = DateTime.Now;

                await _appDbContext.SaveChangesAsync(cancellationToken);
                return new Result { IsSuccess = true, Message = ".به روزرسانی انجام شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> DeleteCategory(Category category, CancellationToken cancellationToken)
        {
            //For Admin 
            var current = await _appDbContext.Categories
                .FirstOrDefaultAsync(c => c.Id == category.Id, cancellationToken);

            if (current is null)
                return new Result { IsSuccess = false, Message = ".نظری با این شناسه یافت نشد" };

            _appDbContext.Categories.Remove(current);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new Result { IsSuccess = true, Message = ".با موفقیت حذف شد" };
        }

        public async Task<Result> SoftDeleteComment(Category category, CancellationToken cancellationToken)
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
    }
}