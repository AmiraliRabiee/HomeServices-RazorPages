using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Contracts.Service.BaseEntities
{
    public interface IBaseDataService
    {
        Task<string> UploadImage(IFormFile FormFile, string folderName, CancellationToken cancellationToken);
        Task<List<City>> GetCities(CancellationToken cancellationToken);
    }
}
