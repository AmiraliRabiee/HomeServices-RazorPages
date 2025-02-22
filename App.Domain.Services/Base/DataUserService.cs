using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Contracts.Service.BaseEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Base
{
    public class DataUserService(ICityRepository _cityRepository) : IBaseDataService
    {
        public List<City> GetCities()
            => _cityRepository.GetCities();

        public async Task<string> UploadImage(IFormFile FormFile, string folderName, CancellationToken cancellationToken)
        {
            string filePath;
            string fileName;
            if (FormFile != null)
            {
                fileName = Guid.NewGuid().ToString() +
                           ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim('"');
                filePath = Path.Combine("wwwroot", "images", folderName, fileName);
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
                return $"/images/{folderName}/{fileName}";
            }
            else
                fileName = "";

            return fileName;
        }
    }

}
