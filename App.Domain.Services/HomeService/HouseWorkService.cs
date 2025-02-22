using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.Services.HomeService
{
    public class HouseWorkService(IHouseWorkRepository _houseWorkRepository) : IHouseWorkService
    {
        public Task<Result> CreateService(SummHouseWorkDto service, CancellationToken cancellationToken)
            => _houseWorkRepository.CreateService(service, cancellationToken);

        public Task<Result> DeleteHomeService(int id, CancellationToken cancellationToken)
            => _houseWorkRepository.DeleteHomeService(id, cancellationToken);

        public Task<List<SummHouseWorkDto>> GetAll(CancellationToken cancellationToken)
            => _houseWorkRepository.GetHomeServices(cancellationToken);

        public HouseWork GetById(int id)
            => _houseWorkRepository.GetHomeServiceById(id);

        public UpdateHouseWork GetServiceDto(int id)
            => _houseWorkRepository.GetServiceDto(id);

        public Task<Result> SoftDeleteHomeService(HouseWork service, CancellationToken cancellationToken)
            => _houseWorkRepository.SoftDeleteHomeService(service, cancellationToken);

        public Task<Result> UpdateHomeService(UpdateHouseWork service, CancellationToken cancellationToken)
            => _houseWorkRepository.UpdateHomeService(service, cancellationToken);
    }
}
