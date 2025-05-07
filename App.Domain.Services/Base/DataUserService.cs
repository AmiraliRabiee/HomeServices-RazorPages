using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Base
{
    public class DataUserService(ICityRepository _cityRepository, IImageRepository _imageRepository) : IBaseDataService
    {
        public async Task<List<City>> GetCitiesAsync(CancellationToken cancellationToken)
            => await _cityRepository.GetCities(cancellationToken);

        public async Task<Result> AddImages(List<string> imgAddress, int orderId, CancellationToken cancellationToken)
            => await _imageRepository.AddImages(imgAddress, orderId, cancellationToken);

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

        public async Task<List<string?>> GetImagesPath(int orderId)
            =>  await _imageRepository.GetImagesPath(orderId);
    }

}
