using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Contracts.Service
{
    public interface IBaseDataService
    {
        Task<string> UploadImage(IFormFile FormFile, string folderName, CancellationToken cancellationToken);

    }
}
