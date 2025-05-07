using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Enum;
using App.Domain.Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Threading;

namespace App.Domain.AppServices.HomeService
{
    public class OrderAppService(IOrderService _orderService
        , ISuggestionService _suggestionService
        , IUserAppService userAppService
        , IBaseDataService _baseDataService) : IOrderAppService
    {

        public async Task<List<SummOrderDto>> GetAll()
            => await _orderService.GetAll();

        public async Task<Result> CreateOrder(SummOrderDto order, CancellationToken cancellationToken)
        {
            try
            {
                var create = await _orderService.Create(order, cancellationToken);
                if (order.Images is not null)
                {
                    var imagesPath = new List<string>();
                    foreach (var image in order.Images)
                    {
                        var imagepath = await _baseDataService.UploadImage(image, "Profiles", cancellationToken);
                        imagesPath.Add(imagepath);
                    }
                    var result = await _baseDataService.AddImages(imagesPath, create, cancellationToken);
                    if (result.IsSuccess)
                    {
                        return new Result { IsSuccess = true, Message = result.Message };
                    }
                }
                return new Result { IsSuccess = true, Message = "سفارش بدون عکس ثبت شده است" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<Result> ChangeStatus(int id, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderById(id, cancellationToken);
            if (order == null)
                return new Result { IsSuccess = false, Message = "سفارش یافت نشد." };

            switch (order.StausService)
            {
                case StausServiceEnum.NewlyRegistered:
                    var result = await _orderService.IsExistSuggestion(id);
                    if (!result.IsSuccess)
                    {
                        await _orderService.ChangeToNewlyRegistered(id, cancellationToken);
                        return new Result { IsSuccess = true, Message = "وضعیت سفارش در 'ثبت شده' باقی ماند" };
                    }
                    await _orderService.ChangeToExpertSelection(id);
                    return new Result { IsSuccess = true, Message = "وضعیت سفارش به 'انتخاب متخصص' تغییر یافت" };

                case StausServiceEnum.ExpertSelectionQueue:
                    var result2 = await _orderService.IsExistSuggestion(id);
                    if (!result2.IsSuccess)
                    {
                        await _orderService.ChangeToNewlyRegistered(id, cancellationToken);
                        return new Result { IsSuccess = true, Message = "وضعیت سفارش 'در انتظار سرویس' باقی ماند" };
                    }
                    await _orderService.ChangeToWaitingForService(id, cancellationToken);
                    return new Result { IsSuccess = false, Message = "پیشنهادی برای این سفارش قبت نشده است" };


                case StausServiceEnum.WaitingForService:
                    await _orderService.ChangeToDone(id, cancellationToken);
                    return new Result { IsSuccess = true, Message = "وضعیت سفارش به 'انجام شده' تغییر یافت" };

                case StausServiceEnum.Done:
                    return new Result { IsSuccess = false, Message = "سفارش قبلاً انجام شده است" };

                default:
                    return new Result { IsSuccess = false, Message = "وضعیت سفارش نامعتبر است" };
            }
        }

        public async Task<List<SummOrderDto>> GetOrdersById(int id, CancellationToken cancellationToken)
            => await _orderService.GetOrdersById(id, cancellationToken);

        public async Task<SummOrderDto?> GetOrderById(int id, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderById(id, cancellationToken);
            if (order is null)
                throw new NotFoundException("سفارش با این شناسه یافت نشئد");
            return order;
        }

        public Task<int> GetActiveServicesCount(int id, CancellationToken cancellationToken)
            => _orderService.GetActiveServicesCount(id, cancellationToken);

        public Task<int> GetDoneServicesCount(int id, CancellationToken cancellationToken)
            => _orderService.GetDoneServicesCount(id, cancellationToken);

        public async Task<List<SummOrderDto>> GetCustomerOrders(int customerId, CancellationToken cancellationToken)
            => await _orderService.GetCustomerOrders(customerId, cancellationToken);

        public Task<Result> Delete(int id, CancellationToken cancellationToken)
            => _orderService.Delete(id, cancellationToken);

        public async Task ChangeToPayment(int id, CancellationToken cancellationToken)
            => await _orderService.ChangeToPayment(id, cancellationToken);

        public async Task<List<SummOrderDto>> GetReserveOrders(AppUser user, CancellationToken cancellationToken)
        {
            var expert = await _orderService.GetExpertWithSkillsAndCity(user.Id, cancellationToken);
            var list = await _orderService.GetOrdersMatchingExpert(expert, cancellationToken);
            return list;
        }

        public async Task<List<SummOrderDto>> GetAcceptedOrders(AppUser user, CancellationToken cancellationToken)
        {
            var expert = await _orderService.GetExpertWithSkillsAndCity(user.Id, cancellationToken);
            var orders = await _orderService.GetOrdersAcceptExpert(expert, cancellationToken);
            return orders;
        }

        public async Task ChangeToDone(int id, CancellationToken cancellationToken)
            => await _orderService.ChangeToDone(id, cancellationToken);

        public async Task<float> GetSuggestPrice(int orderId, CancellationToken cancellationToken)
            => await _orderService.GetSuggestPrice(orderId, cancellationToken);
    }
}
