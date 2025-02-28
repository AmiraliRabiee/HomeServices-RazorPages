using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Core.Contracts.Service.BaseEntities
{
    public interface ICommentService
    {
        Task<Result> AddComment(Comment comment, CancellationToken cancellationToken);
        Task<Result> UpdateComment(Comment comment, CancellationToken cancellationToken);
        Task<Result> SoftDeleteComment(Comment comment, CancellationToken cancellationToken);
        Task<Result> DeleteComment(int id, CancellationToken cancellationToken);
        Task<Result> AcceptComment(int id, CancellationToken cancellationToken);
        List<CommentDto> GetComments();
    }
}
