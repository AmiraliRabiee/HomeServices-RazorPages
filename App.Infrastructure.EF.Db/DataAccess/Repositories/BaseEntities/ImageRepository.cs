using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Infrastructure.EFCore.DataBase.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore.DataAccess.Repositories.BaseEntities
{
    public class ImageRepository(AppDbContext _dbContext) : IImageRepository
    {
        public async Task<Result> AddImages(List<string> imgAddress ,int orderId, CancellationToken cancellationToken)
        {
            try
            {
                var images = imgAddress.Select(x => new Image()
                {
                    Path = x,
                    OrderId = orderId
                });

                await _dbContext.Images.AddRangeAsync(images, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "با موفقیت افزوده شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };

            }
        }

        public async Task<List<string?>> GetImagesPath(int orderId)
            => await _dbContext.Images.Where(i => i.OrderId == orderId).Select(i => i.Path).ToListAsync();
    }
}
