using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Contracts.Repository.User;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Exceptions;
using System.Threading;

namespace App.Domain.Services.Base
{
    public class CommentService(ICommentRepository _commentRepository,
        IExpertRepository _expertRepository) : ICommentService
    {
        public async Task<Result> AcceptComment(int id, CancellationToken cancellationToken)
            => await _commentRepository.AcceptComment(id, cancellationToken);

        public async Task<Result> AddComment(Comment comment, CancellationToken cancellationToken)
            => await _commentRepository.AddComment(comment, cancellationToken);

        public async Task<Result> DeleteComment(int id, CancellationToken cancellationToken)
            => await _commentRepository.DeleteComment(id, cancellationToken);

        public async Task<int> GetAcceptCommentCount(int id, CancellationToken cancellationToken)
            => await _commentRepository.GetAcceptCommentCount(id, cancellationToken);

        public async Task<double?> GetAvg(int id, CancellationToken cancellationToken)
            => await _commentRepository.GetAvg(id, cancellationToken);

        public async Task<List<CommentDto>> GetComments(CancellationToken cancellationToken)
            => await _commentRepository.GetComments(cancellationToken);

        public async Task<List<CommentDto>> GetCommentsById(int expertId, CancellationToken cancellationToken)
        {
            var expert =await  _expertRepository.GetExpertDto(expertId, cancellationToken);
           var comments =  await _commentRepository.GetCommentsById(expertId, cancellationToken);
            //
            return comments;
        }

        public async Task<int> GetCount(int id, CancellationToken cancellationToken)
            => await _commentRepository.GetCount(id, cancellationToken);

        public async Task<int> GetRegisterCommentCount(int id, CancellationToken cancellationToken)
            => await _commentRepository.GetRegisterCommentCount(id, cancellationToken);

        public async Task<Result> RejectComment(int id, CancellationToken cancellationToken)
            => await _commentRepository.RejectComment(id, cancellationToken);
        public Task<Result> SoftDeleteComment(Comment comment, CancellationToken cancellationToken)
            => _commentRepository.SoftDeleteComment(comment, cancellationToken);

        public async Task<Result> UpdateComment(Comment comment, CancellationToken cancellationToken)
            => await _commentRepository.UpdateComment(comment, cancellationToken);


    }
}
