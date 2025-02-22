using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.AppServices.HomeService
{
    public class HouseWorkAppService(IHouseWorkService _houseWorkService, IBaseDataService _baseDataService) : IHouseWorkAppService
    {
        public async Task<Result> AddServiceAsync(SummHouseWorkDto model, CancellationToken cancellationToken)
        {
            if (model.ServiceImage is not null)
            {
                model.ImagePath = await _baseDataService.UploadImage(model.ServiceImage!, "Profiles", cancellationToken);
            }
            var result = await _houseWorkService.CreateService(model, cancellationToken);
            if (result.IsSuccess)
                return new Result {IsSuccess = true, Message = result.Message };
            return new Result { Message = result.Message };
        }

        public async Task<Result> DeLeteServiceAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _houseWorkService.DeleteHomeService(id, cancellationToken);
            if (result.IsSuccess)
                return new Result {IsSuccess = true, Message = result.Message };
            return new Result {IsSuccess = false, Message = result.Message };
        }

        public async Task<Result> UpdateServiceAsync(UpdateHouseWork model, CancellationToken cancellationToken)
        {
            if (model.ServiceImage is not null)
            {
                model.ImagePath = await _baseDataService.UploadImage(model.ServiceImage!, "Profiles", cancellationToken);
            }
            var result = await _houseWorkService.UpdateHomeService(model, cancellationToken);
            if (result.IsSuccess)
                return new Result { IsSuccess = true, Message = result.Message };
            return new Result {IsSuccess = false, Message = result.Message };
        }

        public async Task<Result> SoftDeleteServiceAsync(HouseWork model, CancellationToken cancellationToken)
        {
            var result = await _houseWorkService.SoftDeleteHomeService(model, cancellationToken);
            if (result.IsSuccess)
                return new Result {IsSuccess = true , Message = result.Message };
            return new Result {IsSuccess = false , Message = result.Message };
        }

        public HouseWork GetByIdAsync(int id)
        {
            var result =  _houseWorkService.GetById(id);
            if (result is null)
                return null;
            return result;

        }

        public async Task<List<SummHouseWorkDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _houseWorkService.GetAll(cancellationToken);
            return result;
        }

        public UpdateHouseWork GetServiceDto(int id)
            => _houseWorkService.GetServiceDto(id);
    }
}
