using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Core.Contracts.AppService
{
    public interface ICommentAppService
    {
        Task<Result> Add(Comment comment, CancellationToken cancellationToken);
        Task<Result> Delete(int id, CancellationToken cancellationToken);
        Task<Result> AcceptComment(int id, CancellationToken cancellationToken);
        List<CommentDto> GetComments();
    }
}
