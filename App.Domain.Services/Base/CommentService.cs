using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Services.Base
{
    public class CommentService(ICommentRepository _commentRepository) : ICommentService
    {
        public Task<Result> AcceptComment(Comment model, CancellationToken cancellationToken)
            => _commentRepository.AcceptComment(model, cancellationToken);

        public Task<Result> AddComment(Comment comment, CancellationToken cancellationToken)
            => _commentRepository.AddComment(comment, cancellationToken);

        public Task<Result> DeleteComment(Comment comment, CancellationToken cancellationToken)
            => _commentRepository.DeleteComment(comment, cancellationToken);

        public Task<Result> SoftDeleteComment(Comment comment, CancellationToken cancellationToken)
            => _commentRepository.SoftDeleteComment(comment, cancellationToken);

        public Task<Result> UpdateComment(Comment comment, CancellationToken cancellationToken)
            => _commentRepository.UpdateComment(comment, cancellationToken);
    }
}
