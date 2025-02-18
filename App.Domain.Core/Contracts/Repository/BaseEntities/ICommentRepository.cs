using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Core.Contracts.Repository.BaseEntities
{
    public interface ICommentRepository
    {
        Task<Result> AddComment(Comment comment, CancellationToken cancellationToken);
        Task<Result> UpdateComment(Comment comment, CancellationToken cancellationToken);
        Task<Result> SoftDeleteComment(Comment comment, CancellationToken cancellationToken);
        Task<Result> DeleteComment(Comment comment, CancellationToken cancellationToken);
        Task<Result> AcceptComment(Comment model, CancellationToken cancellationToken);
    }
}
