using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Services.Base
{
    public class CommentService(ICommentRepository _commentRepository) : ICommentService
    {
        public async Task<Result> AcceptComment(int id, CancellationToken cancellationToken)
            =>await _commentRepository.AcceptComment(id, cancellationToken);

        public async Task<Result> AddComment(Comment comment, CancellationToken cancellationToken)
            => await _commentRepository.AddComment(comment, cancellationToken);

        public async Task<Result> DeleteComment(int id, CancellationToken cancellationToken)
            => await _commentRepository.DeleteComment(id, cancellationToken);

        public async Task<int> GetAcceptCommentCount(int id, CancellationToken cancellationToken)
            => await _commentRepository.GetAcceptCommentCount(id, cancellationToken);

        public async Task<double?> GetAvg(int id, CancellationToken cancellationToken)
            => await _commentRepository.GetAvg(id, cancellationToken);    

        public List<CommentDto> GetComments()
            => _commentRepository.GetComments();

        public async Task<List<CommentDto>> GetCommentsById(int expertId, CancellationToken cancellationToken)
            =>await _commentRepository.GetCommentsById(expertId, cancellationToken);

        public async Task<int> GetCount(int id, CancellationToken cancellationToken)
            =>await _commentRepository.GetCount(id, cancellationToken);

        public async Task<int> GetRegisterCommentCount(int id,CancellationToken cancellationToken)
            => await _commentRepository.GetRegisterCommentCount(id,cancellationToken);

        public async Task<Result> RejectComment(int id, CancellationToken cancellationToken)
            => await _commentRepository.RejectComment(id, cancellationToken);
        public Task<Result> SoftDeleteComment(Comment comment, CancellationToken cancellationToken)
            => _commentRepository.SoftDeleteComment(comment, cancellationToken);

        public async Task<Result> UpdateComment(Comment comment, CancellationToken cancellationToken)
            => await _commentRepository.UpdateComment(comment, cancellationToken);


    }
}
