using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Contracts.Service.BaseEntities;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace App.Domain.Services.Base
{
    public class BaseDataService(ICityRepository _cityRepository) : IBaseDataService
    {
        public Task<List<City>> GetCities(CancellationToken cancellationToken)
            => _cityRepository.GetCities(cancellationToken);

        public async Task<string> UploadImage(IFormFile FormFile, string folderName, CancellationToken cancellationToken)
        {
            string filePath;
            string fileName;
            if (FormFile != null)
            {
                fileName = Guid.NewGuid().ToString() +
                           ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim('"');
                filePath = Path.Combine($"wwwroot/~/UserTemplate/images/{folderName}", fileName);
                try
                {
                    using (var stream = File.Create(filePath))
                    {
                        await FormFile.CopyToAsync(stream, cancellationToken);
                    }
                }
                catch
                {
                    throw new Exception("Upload files operation failed");
                }
                return $"/~/UserTemplate/images/{folderName}/{fileName}";
            }
            else
                fileName = "";

            return fileName;
        }
    }
}
