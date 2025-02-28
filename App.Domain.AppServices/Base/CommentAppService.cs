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
        public Task<Result> AcceptComment(int id, CancellationToken cancellationToken)
            => _commentService.AcceptComment(id, cancellationToken);

        public Task<Result> Add(Comment comment, CancellationToken cancellationToken)
            => _commentService.AddComment(comment, cancellationToken);

        public Task<Result> Delete(int id, CancellationToken cancellationToken)
            => _commentService.DeleteComment(id, cancellationToken);

        public List<CommentDto> GetComments()
            => _commentService.GetComments();
    }
}
