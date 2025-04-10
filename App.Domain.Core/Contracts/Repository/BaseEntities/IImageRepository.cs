using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repository.BaseEntities
{
    public interface IImageRepository
    {
        Task<Result> AddImages(List<string> imgAddress, int orderId, CancellationToken cancellationToken);
        Task<List<string?>> GetImagesPath(int orderId);
    }
}
