using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Enum;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.AppServices.HomeService
{
    public class OrderAppService(IOrderService _orderService, ISuggestionService _suggestionService, IUserAppService userAppService) : IOrderAppService
    {

        public async Task<List<SummOrderDto>> GetAll()
            => await _orderService.GetAll();

        public async Task<Result> CreateOrder(AppUser user, SummOrderDto order, CancellationToken cancellationToken)
        {
            var result = await _orderService.Create(order, cancellationToken);
            if (result.IsSuccess)
                return new Result { IsSuccess = true, Message = result.Message };
            return result;
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
                    await _orderService.ChangeToExpertSelection(id, cancellationToken);
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

        public Task<List<SummOrderDto>> GetOrdersById(int id, CancellationToken cancellationToken)
            => _orderService.GetOrdersById(id, cancellationToken);

        public async Task<SummOrderDto> GetOrderById(int id, CancellationToken cancellationToken)
            => await _orderService.GetOrderById(id, cancellationToken);

        public Task<int> GetActiveServicesCount(int id, CancellationToken cancellationToken)
            => _orderService.GetActiveServicesCount(id, cancellationToken);

        public Task<int> GetDoneServicesCount(int id, CancellationToken cancellationToken)
            => _orderService.GetDoneServicesCount(id, cancellationToken);

        public async Task<List<SummOrderDto>> GetCustomerOrders(int customerId, CancellationToken cancellationToken)
            => await _orderService.GetCustomerOrders(customerId, cancellationToken);

        public Task<Result> Delete(int id, CancellationToken cancellationToken)
            => _orderService.Delete(id, cancellationToken);

        public Task ChangeToPayment(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
