using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Core.Contracts.Repository.BaseEntities
{
    public interface ICommentRepository
    {
        Task<Result> AddComment(Comment comment, CancellationToken cancellationToken);
        Task<Result> UpdateComment(Comment comment, CancellationToken cancellationToken);
        Task<Result> SoftDeleteComment(Comment comment, CancellationToken cancellationToken);
        Task<Result> DeleteComment(int id, CancellationToken cancellationToken);
        Task<Result> AcceptComment(int id, CancellationToken cancellationToken);
        Task<Result> RejectComment(int id, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetComments(CancellationToken cancellationToken);
        Task<int> GetRegisterCommentCount(int id,CancellationToken cancellationToken);
        Task<int> GetAcceptCommentCount(int id, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetCommentsById(int expertId, CancellationToken cancellationToken);
        Task<double?> GetAvg(int id, CancellationToken cancellationToken);
        Task<int> GetCount(int id, CancellationToken cancellationToken);
    }
}
