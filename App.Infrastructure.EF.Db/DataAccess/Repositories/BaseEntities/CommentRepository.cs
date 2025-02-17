using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Entites.Result;
using App.Domain.Core.Enums;
using App.Infrastructure.DataBase.EFCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore.DataAccess.Repositories.BaseEntities
{
    public class CommentRepository(AppDbContext _appDbContext) : ICommentRepository
    {
        public async Task<Result> AddComment(Comment comment, CancellationToken cancellationToken)
        {
            //For Customer
            try
            {
                var newComment = new Comment();
                newComment.CreateAt = DateTime.Now;
                newComment.stausService = StausServiceEnum.Done;
                newComment.ExpertId = comment.ExpertId;
                newComment.ExpertRating = comment.ExpertRating;

                await _appDbContext.Comments.AddAsync(newComment, cancellationToken);
                await _appDbContext.SaveChangesAsync();

                return new Result { IsSuccess = true, Message = "با موفقیت افزوده شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> AcceptComment(Comment model , CancellationToken cancellationToken)
        {
            var comment = await _appDbContext.Comments.FindAsync(model.Id);
            if (comment == null)
                return new Result { IsSuccess = false, Message = ".نظری با این شناسه یاقت نشد" };
            comment.IsPlayable = true;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return new Result { IsSuccess = true, Message = ".تایید شد" };
        }

        public async Task<Result> UpdateComment(Comment comment, CancellationToken cancellationToken)
        {
            //For Customer
            try
            {
                var current = await _appDbContext.Comments
                .Include(x => x.ExpertId)
                .FirstOrDefaultAsync(c => c.Id == comment.Id, cancellationToken);

                if (current is null)
                    return new Result { IsSuccess = false, Message = ".نظری با این شناسه یافت نشد" };

                var newComment = new Comment();
                newComment.ExpertRating = comment.ExpertRating;
                newComment.CreateAt = DateTime.Now;

                await _appDbContext.SaveChangesAsync(cancellationToken);
                return new Result { IsSuccess = true, Message = ".به روزرسانی انجام شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> DeleteComment(Comment comment, CancellationToken cancellationToken)
        {
            //For Admin 
            var current = await _appDbContext.Comments
                .Include(x => x.ExpertId)
                .FirstOrDefaultAsync(c => c.Id == comment.Id, cancellationToken);

            if (current is null)
                return new Result { IsSuccess = false, Message = ".نظری با این شناسه یافت نشد" };

            _appDbContext.Comments.Remove(current);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new Result { IsSuccess = true, Message = ".با موفقیت حذف شد" };
        }

        public async Task<Result> SoftDeleteComment(Comment comment, CancellationToken cancellationToken)
        {
            //For Admin 
            var current = await _appDbContext.Comments
                .Include(x => x.ExpertId)
                .FirstOrDefaultAsync(c => c.Id == comment.Id, cancellationToken);

            if (current is null)
                return new Result { IsSuccess = false, Message = ".نظری با این شناسه یافت نشد" };

            comment.IsDeleted = true;
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new Result { IsSuccess = true, Message = ".با موفقیت حذف شد" };
        }
    }
}
