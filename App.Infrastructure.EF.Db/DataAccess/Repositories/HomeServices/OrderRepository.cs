using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Enum;
using App.Infrastructure.EFCore.DataBase.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace App.InfraAccess.EFCore.DataAccess.Repositories.HomeServices
{
    public class OrderRepository(AppDbContext _appDbContext) : IOrderRepository
    {
        #region OrderCrud
        public async Task<int> CreateOrder(SummOrderDto order, CancellationToken cancellationToken)
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
            return newOrder.Id;
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
                .Where(h => h.Customer.User.Id == id)
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

        public async Task<SummOrderDto?> GetOrderById(int id, CancellationToken cancellationToken)
        {
            var order = await _appDbContext.Orders
            .Where(o => o.Id == id)
               .Select(o => new SummOrderDto
               {
                   Id = o.Id,
                   CustomerId = o.CustomerId,
                   HouseWork = o.HouseWork.Title,
                   ImagePath = o.Customer.User.ImagePath,
                   StausService = o.StausService,
                   CompletionDate = o.CompletionDate,
                   RunningTime = o.RunningTime,
                   Description = o.Description,
                   CustomerName = o.Customer.User.FirstName + " " + o.Customer.User.LastName,
                   BasePrice = o.HouseWork.BasePrice,
                   CreationDate = o.CreateAt,
                   IsConfrim = o.IsConfrim,
                   Address = o.Customer.Address,
                   UploadImages = o.Images 
               }).FirstOrDefaultAsync(cancellationToken);
            return order;
        }

        public async Task<List<SummOrderDto>> GetAll()
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
                CustomerName = o.Customer.User.FirstName + " " + o.Customer.User.LastName
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
                CompletionDate = o.CompletionDate,
                RunningTime = o.RunningTime,
                CreationDate = o.CreateAt
            }).OrderByDescending(o => o.CreationDate)
            .ToListAsync();

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

        public async Task ChangeToExpertSelection(int id)
        {
            //2
            var order = await _appDbContext.Orders.FindAsync(id);
            order.IsConfrim = false;
            order.IsFinish = false;
            order.StausService = StausServiceEnum.ExpertSelectionQueue;
            await _appDbContext.SaveChangesAsync();
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

        public async Task<Result> IsExistSuggestion(int id)
        {
            var IsExist = await _appDbContext.Orders
                .Where(o => o.Id == id)
                .AnyAsync(o => o.Suggestions != null);
            if (IsExist is true)
                return new Result { IsSuccess = true, Message = " پیشنهاد وجود دارد" };
            return new Result { IsSuccess = false, Message = "پیشنهاد خالی میباشد" };

        }

        public async Task<List<SummOrderDto>> GetCustomerOrders(int customerId, CancellationToken cancellationToken)
        {

            var orders = await _appDbContext.Orders
            .Where(o => o.CustomerId == customerId)
            .Where(o => o.IsPayment == true)
            .Select(o => new SummOrderDto
            {
                ImagePath = o.HouseWork.ImagePath,
                HouseWork = o.HouseWork.Title,
                StausService = o.StausService,
                BasePrice = o.HouseWork.BasePrice,
                CompletionDate = o.CompletionDate,
                CreationDate = o.CreateAt,
                ExpertName = o.Customer.User.Expert.User.FirstName,
            }).ToListAsync(cancellationToken);

            if (orders is null)
                throw new Exception("هنوز سفارشی ثبت نشده است");
            return orders;
        }

        //public async Task<List<SummOrderDto>> GetReserveOrders(AppUser user, CancellationToken cancellationToken)
        //{
        //        var expert = await GetExpertWithSkillsAndCity(user.Id, cancellationToken);
        //        return await GetOrdersMatchingExpert(expert, cancellationToken);
        //}

        public async Task<Expert?> GetExpertWithSkillsAndCity(int userId, CancellationToken cancellationToken)
        {
            return await _appDbContext.Experts
                .Where(e => e.User!.Id == userId)
                .Select(e => new Expert
                {
                    Id = e.Id,
                    CityId = e.CityId,
                    ExpertWorksSkills = e.ExpertWorksSkills.Select(eh => new ExpertHouseWork
                    {
                        HouseWorkId = eh.HouseWorkId
                    }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<SummOrderDto>> GetOrdersMatchingExpert(Expert expert, CancellationToken cancellationToken)
        {
            var houseWorkIds = expert.ExpertWorksSkills.Select(eh => eh.HouseWorkId).ToList();

            var orders = await _appDbContext.Orders
                .Where(o => houseWorkIds.Contains(o.HouseWorkId) && o.Customer.CityId == expert.CityId &&
                    !o.Suggestions.Any(s => s.IsAccept))
                .Select(o => new SummOrderDto
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    HouseWork = o.HouseWork.Title,
                    ImagePath = o.Customer.User.ImagePath,
                    StausService = o.StausService,
                    CompletionDate = o.CompletionDate,
                    RunningTime = o.RunningTime,
                    Description = o.Description,
                    CustomerName = o.Customer.User.FirstName + " " + o.Customer.User.LastName,
                    BasePrice = o.HouseWork.BasePrice,
                    CreationDate = o.CreateAt
                })
                .ToListAsync(cancellationToken);
            return orders;
        }

        public async Task<List<SummOrderDto>> GetOrdersAcceptExpert(Expert expert, CancellationToken cancellationToken)
        {
            var acceptedOrderIds = await _appDbContext.Suggestions
                .Where(s => s.ExpertId == expert.Id && s.IsAccept == true)
                .Select(s => s.OrderId)
                .ToListAsync(cancellationToken);

            var orders = await _appDbContext.Orders
                .Where(o => acceptedOrderIds.Contains(o.Id))
                .Where(o => o.IsPayment == false)
                .Select(o => new SummOrderDto
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    HouseWork = o.HouseWork.Title,
                    ImagePath = o.Customer.User.ImagePath,
                    StausService = o.StausService,
                    CompletionDate = o.CompletionDate,
                    RunningTime = o.RunningTime,
                    Description = o.Description,
                    CustomerName = o.Customer.User.FirstName + " " + o.Customer.User.LastName,
                    BasePrice = o.HouseWork.BasePrice,
                    CreationDate = o.CreateAt,
                })
                .OrderByDescending(o => o.CreationDate)
                .ToListAsync(cancellationToken);

            return orders;
        }

        public async Task<float> GetSuggestPrice(int orderId, CancellationToken cancellationToken)
        {
            var price = await _appDbContext.Suggestions
                .Where(s => s.OrderId == orderId)
                .Select(s => s.SuggestPrice)
                .FirstOrDefaultAsync(cancellationToken);
            return price;
        }
        #endregion
    }
}
