using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Enum;
using App.Infrastructure.EFCore.DataBase.Common;
using Microsoft.EntityFrameworkCore;

namespace App.InfraAccess.EFCore.DataAccess.Repositories.BaseEntities
{
    public class CommentRepository(AppDbContext _appDbContext) : ICommentRepository
    {
        public async Task<Result> AddComment(Comment comment, CancellationToken cancellationToken)
        {
            // For Customer
            try
            {
                var newComment = new Comment
                {
                    CreateAt = DateTime.Now,
                    stausService = StausServiceEnum.Done,
                    ExpertId = comment.ExpertId,
                    Points = comment.Points,
                    Opinion = comment.Opinion
                };

                await _appDbContext.Comments.AddAsync(newComment, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "با موفقیت افزوده شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> AcceptComment(int id, CancellationToken cancellationToken)
        {
            var comment = await _appDbContext.Comments.FindAsync(id);
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
                newComment.Points = comment.Points; 
                newComment.CreateAt = DateTime.Now;

                await _appDbContext.SaveChangesAsync(cancellationToken);
                return new Result { IsSuccess = true, Message = ".به روزرسانی انجام شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> DeleteComment(int id, CancellationToken cancellationToken)
        {
            //For Admin 
            var current = await _appDbContext.Comments
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

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

        public List<CommentDto> GetComments()
        {
            var comments = _appDbContext.Comments
                 .Where(x => !x.IsPlayable)
                .Select(x => new CommentDto
                {
                    Id = x.Id,
                    ExpertName = x.Expert.User.FirstName + x.Expert.User.LastName,
                    Opinion = x.Opinion,
                    Points = x.Points,
                    RegissterDate = x.CreateAt
                }).ToList();
            if (comments is null)
                throw new Exception("کامنتی وجود ندارد");
            return comments;
        }
    }
}
