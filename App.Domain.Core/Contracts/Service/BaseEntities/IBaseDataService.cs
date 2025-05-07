using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Contracts.Service.BaseEntities
{
    public interface IBaseDataService
    {
        Task<string> UploadImage(IFormFile FormFile, string folderName, CancellationToken cancellationToken);
        Task<List<City>> GetCitiesAsync(CancellationToken cancellationToken);
        Task<Result> AddImages(List<string> imgAddress, int orderId, CancellationToken cancellationToken);
        Task<List<string?>> GetImagesPath(int orderId);
    }
}
