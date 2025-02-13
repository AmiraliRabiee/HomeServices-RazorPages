﻿using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.Result;
using App.Domain.Core.Enums;
using App.Infrastructure.DataBase.EFCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore.DataAccess.Repositories.HomeServices
{
    public class OrderRepository(AppDbContext _appDbContext)
    {
        #region OrderCrud
        public async Task<Result> CreateOrder(SummOrderDto order, CancellationToken cancellationToken)
        {
            try
            {
                var newOrder = new Order();

                newOrder.Description = order.Description;
                newOrder.Price = order.BasePrice;
                newOrder.CompletionDate = order.CompletionDate;
                newOrder.RunningTime = order.RunningTime;
                newOrder.CreateAt = DateTime.Now;
                newOrder.StausService = StausServiceEnum.NewlyRegistered;
                newOrder.CustomerId = order.CustomerId;
                newOrder.HomeServiceId = order.HomeServiceId;
                newOrder.CityId = order.CityId;

                await _appDbContext.Orders.AddAsync(newOrder, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "با موفقیت افزوده شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> DeleteOrder(Order order, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _appDbContext.Orders.FirstOrDefaultAsync(t => t.Id == order.Id);

                if (result is null)
                    return new Result { IsSuccess = false, Message = ".سفارشی با این شناسه یافت نشد" };


                _appDbContext.Orders.Remove(result);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "با موفقیت حذف شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> UpdateOrder(Order order, CancellationToken cancellationToken)
        {
            try
            {
                var currentOrder = await _appDbContext.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);

                if (currentOrder is null)
                    return new Result { IsSuccess = false, Message = ".سفارشی با این شناسه یافت نشد" };

                currentOrder.Description = order.Description;
                currentOrder.Price = order.Price;
                currentOrder.CityId = order.CityId;

                await _appDbContext.SaveChangesAsync(cancellationToken);
                return new Result { IsSuccess = true, Message = ".به روزرسانی انجام شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }


        public async Task<Order> GetOrderById(int id, CancellationToken cancellationToken)
        {
            var order = await _appDbContext.Orders
            .Include(o => o.HomeService)
            .Include(o => o.Customer)
            .FirstOrDefaultAsync(o => o.Id == id);

            if (order is null)
                throw new Exception(".سفارشی با این شناسه یافت نشد");

            return order;
        }

        public async Task<List<SummOrderDto>> GetOrders()
        {
            var orders = await _appDbContext.Orders
            .Select(o => new SummOrderDto
            {
                Description = o.Description,
                BasePrice = o.Price,
                HomeServiceId = o.HomeServiceId,
                CustomerId = o.CustomerId,
                CityId = o.CityId,
                CompletionDate = o.CompletionDate,
                RunningTime = o.RunningTime,
            }).ToListAsync();

            if (orders is null)
                throw new Exception(".لیست سفارش ها خالی میباشد");

            return orders;
        }
        #endregion
    }
}
