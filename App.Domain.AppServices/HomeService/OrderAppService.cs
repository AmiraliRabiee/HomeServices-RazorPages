using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Enum;

namespace App.Domain.AppServices.HomeService
{
    public class OrderAppService(IOrderService _orderService, ISuggestionService _suggestionService) : IOrderAppService
    {

        public async Task<List<SummOrderDto>> GetAll()
            => await _orderService.GetAll();

        //public async Task<Result> ChangeStatus(int id, CancellationToken cancellationToken)
        //{
        //    var finished = await _orderService.CheckIsFinish(id, cancellationToken);
        //    if (!finished.IsSuccess)
        //        await _orderService.ChangeToDone(id, cancellationToken);

        //    var confirmed = await _orderService.CheckIsConfrim(id, cancellationToken);
        //    if (!confirmed.IsSuccess)
        //        await _orderService.ChangeToWaitingForService(id, cancellationToken);

        //    var existSuggestion = await _orderService.IsExistSuggestion(id);
        //    if (existSuggestion.IsSuccess)
        //        await _orderService.ChangeToExpertSelection(id, cancellationToken);


        //    return new Result { IsSuccess = false, Message = "با خطا مواجه شد" };
        //}


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
    }
}
