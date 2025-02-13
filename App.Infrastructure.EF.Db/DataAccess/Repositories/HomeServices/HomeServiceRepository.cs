using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites;
using App.Domain.Core.Entites.Result;
using App.Infrastructure.DataBase.EFCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore.DataAccess.Repositories
{
    public class HomeServiceRepository(AppDbContext _appDbContext) : IHomeServiceRepository
    {
        #region HomeServiceCrud
        public async Task<Result> CreateService(SummHomeServiceDto service, CancellationToken cancellationToken)
        {
            try
            {
                var newService = new HomeService();
                newService.Description = service.Description;
                newService.BasePrice = service.BasePrice;
                newService.ImagePath = service.ImagePath;
                newService.CustomerId = service.CustomerId;
                newService.CategoryId = service.SubCategoryId;

                await _appDbContext.HomeServices.AddAsync(newService, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "با موفقیت افزوده شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> DeleteHomeService(HomeService service, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _appDbContext.HomeServices.FirstOrDefaultAsync(h => h.Id == service.Id);

                if (result is null)
                    return new Result { IsSuccess = false, Message = ".سفارشی با این شناسه یافت نشد" };


                _appDbContext.HomeServices.Remove(result);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "با موفقیت حذف شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> UpdateHomeService(HomeService service, CancellationToken cancellationToken)
        {
            try
            {
                var current = await _appDbContext.HomeServices.FirstOrDefaultAsync(h => h.Id == service.Id);

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

        public async Task<HomeService> GetHomeServiceById(int id, CancellationToken cancellationToken)
        {
            var service = await _appDbContext.HomeServices
            .Include(h => h.CategoryId)
            .Include(h => h.CustomerId)
            .FirstOrDefaultAsync(h => h.Id == id);

            if (service is null)
                throw new Exception(".سفارشی با این شناسه یافت نشد");

            return service;
        }

        public async Task<List<SummHomeServiceDto>> GetHomeService()
        {
            var services = await _appDbContext.HomeServices
                .Include(h => h.Category)
                .Include(h => h.Customer)
            .Select(h => new SummHomeServiceDto
            {
                Description = h.Description,
                BasePrice = h.BasePrice,
                SubCategoryId = h.CategoryId,
                //maby
                CustomerId = h.CustomerId,
            }).ToListAsync();

            if (services is null)
                throw new Exception(".لیست سفارش ها خالی میباشد");

            return services;
        }
        #endregion
    }
}
