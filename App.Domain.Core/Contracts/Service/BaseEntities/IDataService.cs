using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Contracts.Service.BaseEntities
{
    public interface IDataService
    {
        Task<string> UploadImage(IFormFile FormFile, string folderName, CancellationToken cancellationToken);

    }
}
