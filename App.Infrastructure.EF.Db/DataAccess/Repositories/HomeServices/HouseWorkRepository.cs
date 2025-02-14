using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites;
using App.Domain.Core.Entites.Result;
using App.Infrastructure.DataBase.EFCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore.DataAccess.Repositories
{
    public class HouseWorkRepository(AppDbContext _appDbContext) : IHouseWorkRepository
    {
        #region HomeServiceCrud
        public async Task<Result> CreateService(HouseWork service, CancellationToken cancellationToken)
        {
            try
            {
                var newService = new HouseWork();
                newService.Description = service.Description;
                newService.BasePrice = service.BasePrice;
                newService.ImagePath = service.ImagePath;
                newService.CustomerId = service.CustomerId;
                newService.CategoryId = service.CategoryId;

                await _appDbContext.HouseWorks.AddAsync(newService, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "با موفقیت افزوده شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> DeleteHomeService(HouseWork service, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _appDbContext.HouseWorks
                    .FirstOrDefaultAsync(h => h.Id == service.Id, cancellationToken);

                if (result is null)
                    return new Result { IsSuccess = false, Message = ".سفارشی با این شناسه یافت نشد" };


                _appDbContext.HouseWorks.Remove(result);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "با موفقیت حذف شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> SoftDeleteHomeService(HouseWork service, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _appDbContext.HouseWorks
                    .FirstOrDefaultAsync(h => h.Id == service.Id, cancellationToken);

                if (result is null)
                    return new Result { IsSuccess = false, Message = ".سفارشی با این شناسه یافت نشد" };

                result.IsDeleted = true;
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "با موفقیت حذف شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> UpdateHomeService(HouseWork service, CancellationToken cancellationToken)
        {
            try
            {
                var current = await _appDbContext.HouseWorks
                    .FirstOrDefaultAsync(h => h.Id == service.Id, cancellationToken);

                if (current is null)
                    return new Result { IsSuccess = false, Message = ".سفارشی با این شناسه یافت نشد" };

                current.Description = service.Description;
                current.BasePrice = service.BasePrice;
                current.ViewCount = service.ViewCount;
                current.CategoryId = service.CategoryId;

                await _appDbContext.SaveChangesAsync(cancellationToken);
                return new Result { IsSuccess = true, Message = ".به روزرسانی انجام شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<HouseWork> GetHomeServiceById(int id, CancellationToken cancellationToken)
        {
            var service = await _appDbContext.HouseWorks
            .Include(h => h.Category)
            .Include(h => h.Customer)
            .FirstOrDefaultAsync(h => h.Id == id, cancellationToken);

            if (service is null)
                throw new Exception(".سفارشی با این شناسه یافت نشد");

            return service;
        }

        public async Task<List<SummHouseWorkDto>> GetHomeService()
        {
            var services = await _appDbContext.HouseWorks
            .Select(h => new SummHouseWorkDto
            {
                Id = h.Id,
                Tiltle = h.Title,
                Description = h.Description,
                BasePrice = h.BasePrice,
                SubCategory = h.Category.Title,
                ImagePath = h.Image.Path == null ? null : h.Image.Path
            }).ToListAsync();

            if (services is null)
                throw new Exception(".لیست سفارش ها خالی میباشد");

            return services;
        }
        #endregion
    }
}
