﻿using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;
using App.Infrastructure.EFCore.DataBase.Common;
using Microsoft.EntityFrameworkCore;

namespace App.InfraAccess.EFCore.DataAccess.Repositories.HomeServices
{
    public class HouseWorkRepository(AppDbContext _appDbContext) : IHouseWorkRepository
    {
        #region HomeServiceCrud
        public async Task<Result> CreateService(SummHouseWorkDto service, CancellationToken cancellationToken)
        {
            try
            {
                var newService = new HouseWork();
                newService.Title = service.Tiltle;
                newService.Description = service.Description;
                newService.BasePrice = service.BasePrice;
                newService.ImagePath = service.ImagePath;
                newService.CategoryId = service.SubCategoryId;

                await _appDbContext.HouseWorks.AddAsync(newService, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "با موفقیت افزوده شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> DeleteHomeService(int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _appDbContext.HouseWorks
                    .FirstOrDefaultAsync(h => h.Id == id, cancellationToken);

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

        public async Task<Result> UpdateHomeService(UpdateHouseWork service, CancellationToken cancellationToken)
        {
            try
            {
                var current = await _appDbContext.HouseWorks
                    .FirstOrDefaultAsync(h => h.Id == service.Id, cancellationToken);

                if (current is null)
                    return new Result { IsSuccess = false, Message = ".سفارشی با این شناسه یافت نشد" };

                current.Title = service.Tiltle;
                current.Description = service.Description;
                current.BasePrice = service.BasePrice;
                current.CategoryId = service.SubCategoryId;
                current.ImagePath = service.ImagePath;

                await _appDbContext.SaveChangesAsync(cancellationToken);
                return new Result { IsSuccess = true, Message = ".به روزرسانی انجام شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<int> GetServiceCount(int categoryId)
        {
            var count = await _appDbContext.HouseWorks
                .Include(h => h.Category)
                .Where(h => h.Category.ParentId == categoryId)
                .CountAsync();
            return count;
        }

        public HouseWork GetHomeServiceById(int id)
        {
            var service = _appDbContext.HouseWorks
            .Include(h => h.Category)
            .FirstOrDefault(h => h.Id == id);

            if (service is null)
                throw new Exception(".سفارشی با این شناسه یافت نشد");

            return service;
        }

        public async Task<List<SummHouseWorkDto>> GetHomeServices(CancellationToken cancellationToken)
        {
            var services = await _appDbContext.HouseWorks
             .Include(h => h.Image)
            .Select(h => new SummHouseWorkDto
            {
                Id = h.Id,
                Tiltle = h.Title,
                Description = h.Description,
                BasePrice = h.BasePrice,
                SubCategory = h.Category.Title,
                ImagePath = h.ImagePath
            }).ToListAsync(cancellationToken);

            if (services is null)
                throw new Exception(".لیست سفارش ها خالی میباشد");

            return services;
        }

        public UpdateHouseWork GetServiceDto(int id)
        {
            var work = _appDbContext.HouseWorks
                .Where(c => c.Id == id)
                .Select(c => new UpdateHouseWork
                {
                    Id = c.Id,
                    BasePrice = c.BasePrice,
                    Description = c.Description,
                    Tiltle = c.Title,
                    ImagePath = c.ImagePath,
                    SubCategoryId = c.CategoryId

                })
                .FirstOrDefault();

            if (work is null)
                throw new Exception("دسته بندی یافت نشد");

            return work;
        }

        public async Task<List<SummHouseWorkDto>> GetServicesById(int id, CancellationToken cancellationToken)
        {
            var service = await _appDbContext.HouseWorks
            .Include(h => h.Category)
            .Where(h => h.Category.ParentId == id)
            .Select(h => new SummHouseWorkDto
            {
                Id = h.Id,
                ImagePath = h.ImagePath,
                Description = h.Description,
                Tiltle = h.Title,
                BasePrice = h.BasePrice,
                SubCategoryId = h.Category.Id,
                CategoryName = h.Category.Title,
            }).ToListAsync(cancellationToken);

            if (service is null)
                throw new Exception(".سفارشی با این شناسه یافت نشد");

            return service;
        }


        public async Task<List<SummHouseWorkDto>> GetServicesByChildId(int id, CancellationToken cancellationToken)
        {
            var service = await _appDbContext.HouseWorks
            .Include(h => h.Category)
            .Where(h => h.CategoryId == id)
            .Select(h => new SummHouseWorkDto
            {
                Id = h.Id,
                ImagePath = h.ImagePath,
                Description = h.Description,
                Tiltle = h.Title,
                BasePrice = h.BasePrice,
                SubCategoryId = h.CategoryId
            }).ToListAsync(cancellationToken);

            if (service is null)
                throw new Exception(".سفارشی با این شناسه یافت نشد");

            return service;
        }

        public async Task<SummHouseWorkDto> GetServiceById(int id, CancellationToken cancellationToken)
        {
            var service = await _appDbContext.HouseWorks
            .Select(h => new SummHouseWorkDto
            {
                Id = h.Id,
                ImagePath = h.ImagePath,
                Description = h.Description,
                Tiltle = h.Title,
                BasePrice = h.BasePrice,
                CategoryName = h.Category.ParentCategory.Title,
                CategoryId = h.Category.Id
            }).FirstOrDefaultAsync(h=> h.Id == id,cancellationToken);

            if (service is null)
                throw new Exception(".سفارشی با این شناسه یافت نشد");

            return service;
        }


        public async Task<CategoryDto> GetCategoryByServiceId(int id, CancellationToken cancellationToken)
        {
            var service = await _appDbContext.HouseWorks
                .Where(h => h.Id == id)
            .Select(h => new CategoryDto
            {
                Id = h.Id,
                ImagePath = h.ImagePath,
                Title = h.Category.Title,
                ParentId = h.Category.ParentId,
                HouseWorkName = h.Title
            }).FirstOrDefaultAsync( cancellationToken);

            if (service is null)
                throw new Exception(".سفارشی با این شناسه یافت نشد");

            return service;
        }

        public List<SummHouseWorkDto> GetServicesById()
        {
            var service = _appDbContext.HouseWorks
            .Where(h => h.CategoryId == 9)
            .Select(h => new SummHouseWorkDto
            {
                ImagePath = h.ImagePath,
                Description = h.Description,
                Tiltle = h.Title,
                BasePrice = h.BasePrice,
            }).ToList();

            if (service is null)
                throw new Exception(".سفارشی با این شناسه یافت نشد");

            return service;
        }

        public async Task<SummHouseWorkDto> GetServiceByChildId(int id, CancellationToken cancellationToken)
        {
            var service = await _appDbContext.HouseWorks
            .Where(h => h.Id == id)
            .Select(h => new SummHouseWorkDto
            {
                Id = h.Id,
                ImagePath = h.ImagePath,
                Description = h.Description,
                Tiltle = h.Title,
                BasePrice = h.BasePrice,
                CategoryName = h.Category.ParentCategory.Title,
                CategoryId = h.Category.Id
            }).FirstOrDefaultAsync(cancellationToken);

            if (service is null)
                throw new Exception(" با این شناسه یافت نشد");

            return service;
        }
        #endregion
    }
}
