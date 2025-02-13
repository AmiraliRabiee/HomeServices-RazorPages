using App.Domain.Core.Entites.Result;

namespace App.Domain.Core.Contracts.Repository.BaseEntities
{
    public interface ICommentRepository
    {
        Task<Result> AddComment(Comment comment, CancellationToken cancellationToken);
        Task<Result> UpdateComment(Comment comment, CancellationToken cancellationToken);
        Task<Result> DeleteComment(Comment comment, CancellationToken cancellationToken);
    }
}
