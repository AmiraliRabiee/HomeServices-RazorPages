using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.AppServices.HomeService
{
    public class HouseWorkAppService(IHouseWorkService _houseWorkService) : IHouseWorkAppService
    {
        public async Task<Result> AddServiceAsync(HouseWork model, CancellationToken cancellationToken)
        {
            var result = await _houseWorkService.CreateService(model, cancellationToken);
            if (result.IsSuccess)
                return new Result { Message = result.Message };
            return new Result { Message = result.Message };
        }

        public async Task<Result> DeLeteServiceAsync(HouseWork model, CancellationToken cancellationToken)
        {
            var result = await _houseWorkService.DeleteHomeService(model, cancellationToken);
            if (result.IsSuccess)
                return new Result { Message = result.Message };
            return new Result { Message = result.Message };
        }

        public async Task<Result> UpdateServiceAsync(HouseWork model, CancellationToken cancellationToken)
        {
            var result = await _houseWorkService.UpdateHomeService(model, cancellationToken);
            if (result.IsSuccess)
                return new Result { Message = result.Message };
            return new Result { Message = result.Message };
        }

        public async Task<Result> SoftDeleteServiceAsync(HouseWork model, CancellationToken cancellationToken)
        {
            var result = await _houseWorkService.SoftDeleteHomeService(model, cancellationToken);
            if (result.IsSuccess)
                return new Result { Message = result.Message };
            return new Result { Message = result.Message };
        }

        public async Task<Result> GetByIdAsync(HouseWork model, CancellationToken cancellationToken)
        {
            var result = await _houseWorkService.GetById(model.Id, cancellationToken);
            if (result is null)
                return new Result { IsSuccess = true, Message = ".سرویس با این شناسه یافت نشد" };
            return new Result { IsSuccess = true, Message = ".با موفقیت انجام شد" };
        }

        public async Task<List<SummHouseWorkDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _houseWorkService.GetAll(cancellationToken);
            return result;
        }
    }
}
