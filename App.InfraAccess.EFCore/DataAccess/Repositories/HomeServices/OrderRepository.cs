using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Enum;
using App.Infrastructure.EFCore.DataBase.Common;
using Microsoft.EntityFrameworkCore;

namespace App.InfraAccess.EFCore.DataAccess.Repositories.HomeServices
{
    public class OrderRepository(AppDbContext _appDbContext) : IOrderRepository
    {
        #region OrderCrud
        public async Task<Result> CreateOrder(SummOrderDto order, CancellationToken cancellationToken)
        {
            try
            {
                var newOrder = new Order
                {
                    Description = order.Description,
                    CompletionDate = order.CompletionDate,
                    RunningTime = order.RunningTime,
                    CreateAt = DateTime.Now,
                    StausService = StausServiceEnum.NewlyRegistered,
                    CustomerId = order.CustomerId,
                    HouseWorkId = order.HouseWorkId,
                };

                await _appDbContext.Orders.AddAsync(newOrder, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "با موفقیت افزوده شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> DeleteOrder(int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _appDbContext.Orders
                    .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

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

        public async Task<int> GetActiveServicesCount(int id, CancellationToken cancellationToken)
        {
            var count = await _appDbContext.Orders
                .Where(h => h.CustomerId == id && h.IsPayment == false)
                .CountAsync(cancellationToken);
            return count;
        }

        public async Task<int> GetDoneServicesCount(int id, CancellationToken cancellationToken)
        {
            var count = await _appDbContext.Orders
                .Where(h => h.CustomerId == id)
                .Where(h => h.IsPayment == true)
                .CountAsync(cancellationToken);
            return count;
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



        public async Task<SummOrderDto> GetOrderById(int id, CancellationToken cancellationToken)
        {
            var order = await _appDbContext.Orders
            .Where(o => o.Id == id)
            .Select(o => new SummOrderDto
            {
                Id = o.Id,
                StausService = o.StausService,
                Description = o.Description,
                HouseWork = o.HouseWork.Title,
                RunningTime = o.RunningTime,
                CompletionDate = o.CompletionDate,
            }).FirstOrDefaultAsync(cancellationToken);

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

        public async Task<List<SummOrderDto>> GetOrdersById(int id, CancellationToken cancellationToken)
        {
            var orders = await _appDbContext.Orders
                .Where(s => s.CustomerId == id)
            .Select(o => new SummOrderDto
            {
                Id = o.Id,
                ImagePath = o.HouseWork.ImagePath,
                Description = o.Description,
                HouseWork = o.HouseWork.Title,
                BasePrice = o.HouseWork.BasePrice,
                CityName = o.Customer.City.Name,
                StausService = o.StausService,
            }).ToListAsync();

            if (orders is null)
                throw new Exception(".لیست سفارش ها خالی میباشد");

            return orders;
        }

        public async Task ChangeToPayment(int id, CancellationToken cancellationToken)
        {
            //5
            var order = await _appDbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
            order.IsFinish = true;
            order.IsConfrim = true;
            order.IsPayment = true;
            order.StausService = StausServiceEnum.Payment;
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task ChangeToDone(int id, CancellationToken cancellationToken)
        {
            //4
            var order = await _appDbContext.Orders.FindAsync(id);
            order.IsFinish = true;
            order.IsConfrim = true;
            order.StausService = StausServiceEnum.Done;
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task ChangeToExpertSelection(int id, CancellationToken cancellationToken)
        {
            //2
            var order = await _appDbContext.Orders.FindAsync(id);
            order.IsConfrim = false;
            order.IsFinish = false;
            order.StausService = StausServiceEnum.ExpertSelectionQueue;
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task ChangeToWaitingForService(int id, CancellationToken cancellationToken)
        {
            //3
            var order = await _appDbContext.Orders.FindAsync(id);
            order.IsConfrim = true;
            order.IsFinish = false;
            order.StausService = StausServiceEnum.WaitingForService;
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task ChangeToNewlyRegistered(int id, CancellationToken cancellationToken)
        {
            //1
            var order = await _appDbContext.Orders.FindAsync(id);
            order.IsFinish = false;
            order.IsConfrim = false;
            order.StausService = StausServiceEnum.NewlyRegistered;
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Result> CheckIsConfrim(int id, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Orders.
                Where(o => o.Id == id)
                .AnyAsync(o => o.IsConfrim == true, cancellationToken);
            if (result is true)
                return new Result { IsSuccess = true, Message = ".این سفارش پذدیرفته شده" };
            return new Result { IsSuccess = false, Message = "این سفارش در انتظار پذیرش توسط کارشناس میباشد." };
        }

        public async Task<Result> CheckIsFinish(int id, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Orders
                 .Where(o => o.Id == id)
                .AnyAsync(o => o.IsFinish == true, cancellationToken);
            if (result is true)
                return new Result { IsSuccess = true, Message = ".این سفارش تمام شده" };
            return new Result { IsSuccess = false, Message = "این سفارش در انتظار تحویل میباشد." };
        }

        public async Task<Result> IsExistSuggestion(int id)
        {
            var IsExist = await _appDbContext.Orders
                .Where(o => o.Id == id)
                .AnyAsync(o => o.Suggestions != null);
            if (IsExist is true)
                return new Result { IsSuccess = true, Message = " پیشنهاد وجود دارد" };
            return new Result { IsSuccess = false, Message = "پیشنهاد خالی میباشد" };

        }

        //public async Task<List<SummSuggestionDto>> GetSuggestionsByCustomerId(int id)
        //{
        //    _appDbContext.Orders
        //        .Where(c => c.CustomerId == id && c.IsConfrim == true)
        //        .Select(c => new SummSuggestionDto
        //        {
        //            ExpertId = c.Suggestions.FirstOrDefault().Id
        //        });
                
        //}

        public async Task<List<SummOrderDto>> GetCustomerOrders(int customerId, CancellationToken cancellationToken)
        {

            var orders = await _appDbContext.Orders
            .Where(o => o.CustomerId == customerId)
            .Select(o => new SummOrderDto
            {
                ImagePath = o.HouseWork.ImagePath,
                HouseWork = o.HouseWork.Title,
                StausService = o.StausService,
                BasePrice = o.HouseWork.BasePrice,
                CompletionDate = o.CompletionDate,
                CreationDate = o.CreateAt,
                ExpertName = o.Customer.User.Expert.User.FirstName
            }).ToListAsync(cancellationToken);

            if (orders is null)
                throw new Exception("هنوز سفارشی ثبت نشده است");

            return orders;

        }
        #endregion
    }
}
