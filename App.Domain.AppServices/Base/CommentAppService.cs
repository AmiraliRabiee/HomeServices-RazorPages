using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.OutputResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Base
{
    public class CommentAppService(ICommentService _commentService) : ICommentAppService
    {
        public async  Task<Result> AcceptComment(int id, CancellationToken cancellationToken)
            =>await _commentService.AcceptComment(id, cancellationToken);

        public async  Task<Result> Add(Comment comment, CancellationToken cancellationToken)
            =>await _commentService.AddComment(comment, cancellationToken);

        public async Task<Result> Delete(int id, CancellationToken cancellationToken)
            =>await _commentService.DeleteComment(id, cancellationToken);

        public async Task<double?> GetAvg(int id, CancellationToken cancellationToken)
            => await _commentService.GetAvg(id, cancellationToken);

        public List<CommentDto> GetComments()
            => _commentService.GetComments();

        public async Task<List<CommentDto>> GetCommentsById(int expertId, CancellationToken cancellationToken)
            => await _commentService.GetCommentsById(expertId, cancellationToken);

        public async  Task<int> GetCount(int id, CancellationToken cancellationToken)
            =>await _commentService.GetCount(id, cancellationToken);
    }
}
