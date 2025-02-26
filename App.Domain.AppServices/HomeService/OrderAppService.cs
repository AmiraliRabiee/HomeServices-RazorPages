using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.AppServices.HomeService
{
    public class OrderAppService(IOrderService _orderService , ISuggestionService _suggestionService) : IOrderAppService
    {

        public async Task<List<SummOrderDto>> GetAll()
            => await _orderService.GetAll();

        public async Task<Result> ChangeStatus(int id, CancellationToken cancellationToken)
        {
            var amount = _suggestionService.GetCount(id);
            if (amount < 1) 
                return new Result { IsSuccess = false, Message = "سفارش هنوز ثبت نشده است" };

            await _orderService.ChangeToExpertSelection(id, cancellationToken);

            var confirmed = await _orderService.CheckIsConfrim(id, cancellationToken);
            if (!confirmed.IsSuccess)
                return new Result { IsSuccess = false, Message = "برای این سفارش هنوز پیشنهادی ثبت نشده" };

            await _orderService.ChangeToWaitingForService(id, cancellationToken);

            var finished = await _orderService.CheckIsFinish(id, cancellationToken);
            if (!finished.IsSuccess)
                return new Result { IsSuccess = false, Message = "سفارش هنوز تکمیل نشده است" };

            await _orderService.ChangeToDone(id, cancellationToken);

            return new Result { IsSuccess = true, Message = "وضعیت سفارش با موفقیت تغییر کرد" };
        }

    }
}
