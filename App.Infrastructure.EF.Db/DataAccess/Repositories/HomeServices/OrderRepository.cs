using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Enum;
using App.Infrastructure.EFCore.DataBase.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore.DataAccess.Repositories.HomeServices
{
    public class OrderRepository(AppDbContext _appDbContext) : IOrderRepository
    {
        #region OrderCrud
        public async Task<Result> CreateOrder(Order order, CancellationToken cancellationToken)
        {
            try
            {
                var newOrder = new Order();

                newOrder.Description = order.Description;
                newOrder.CompletionDate = order.CompletionDate;
                newOrder.RunningTime = order.RunningTime;
                newOrder.CreateAt = DateTime.Now;
                newOrder.StausService = StausServiceEnum.NewlyRegistered;
                newOrder.CustomerId = order.CustomerId;
                newOrder.HouseWorkId = order.HouseWorkId;

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
                var result = await _appDbContext.Orders
                    .FirstOrDefaultAsync(t => t.Id == order.Id, cancellationToken);

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

        public async Task<Result> SoftDeleteOrder(Order order, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _appDbContext.Orders
                    .FirstOrDefaultAsync(t => t.Id == order.Id, cancellationToken);

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


        public async Task<Result> UpdateOrder(Order order, CancellationToken cancellationToken)
        {
            try
            {
                var currentOrder = await _appDbContext.Orders
                    .FirstOrDefaultAsync(o => o.Id == order.Id, cancellationToken);

                if (currentOrder is null)
                    return new Result { IsSuccess = false, Message = ".سفارشی با این شناسه یافت نشد" };

                currentOrder.Description = order.Description;
                currentOrder.CompletionDate = order.CompletionDate;
                currentOrder.RunningTime = order.RunningTime;

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
            .Include(o => o.HouseWork)
            .Include(o => o.Customer)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

            if (order is null)
                throw new Exception(".سفارشی با این شناسه یافت نشد");

            return order;
        }

        public async Task<List<SummOrderDto>> GetOrders()
        {
            var orders = await _appDbContext.Orders
            .Select(o => new SummOrderDto
            {
                Id = o.Id,
                Description = o.Description,
                HouseWork = o.HouseWork.Title,
                CustomerId = o.Customer.Id,
                CompletionDate = o.CompletionDate,
                RunningTime = o.RunningTime,
                StausService = o.StausService,
            }).ToListAsync();

            if (orders is null)
                throw new Exception(".لیست سفارش ها خالی میباشد");

            return orders;
        }

        public async Task ChangeToDone(int id,CancellationToken cancellationToken)
        {
            //4
            var order = await _appDbContext.Orders.FindAsync(id);
            order.StausService = StausServiceEnum.Done;
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task ChangeToExpertSelection(int id, CancellationToken cancellationToken)
        {
            //2
            var order = await _appDbContext.Orders.FindAsync(id);
            order.StausService = StausServiceEnum.ExpertSelectionQueue;
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task ChangeToWaitingForService(int id, CancellationToken cancellationToken)
        {
            //3
            var order = await _appDbContext.Orders.FindAsync(id);
            order.StausService = StausServiceEnum.WaitingForService;
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task ChangeToNewlyRegistered(int id, CancellationToken cancellationToken)
        {
            //1
            var order = await _appDbContext.Orders.FindAsync(id);
            order.StausService = StausServiceEnum.NewlyRegistered;
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Result> CheckIsConfrim(int id, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Orders
                .Where(o => o.Id == id)
                .AnyAsync(o => o.IsConfrim == true);
            if(result is true)
                return new Result { IsSuccess = true};
            return new Result { IsSuccess = false };
        }
        public async Task<Result> CheckIsFinish(int id, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Orders
                .Where(o => o.Id == id)
                .AnyAsync(o => o.IsFinish == true);
            if (result is true)
                return new Result { IsSuccess = true };
            return new Result { IsSuccess = false };
        }

        //public async Task<List<Order>> GetOrdersForExpert(Order model , CancellationToken cancellationToken)
        //{
        //    var orders = await _appDbContext.Orders
        //        .Where( o => o.CityId == model.Expert.CityId && o.HouseWork == model.Expert.Skills)
        //        .ToListAsync(cancellationToken);
        //    if (orders == null)
        //        throw new Exception(".لیست سفارش ها خالی میباشد");
        //    return orders;
        //}



        #endregion
    }
}
