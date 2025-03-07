using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.Services.HomeService
{
    public class HouseWorkService(IHouseWorkRepository _houseWorkRepository) : IHouseWorkService
    {
        public async Task<Result> CreateService(SummHouseWorkDto service, CancellationToken cancellationToken)
            => await _houseWorkRepository.CreateService(service, cancellationToken);

        public async Task<Result> DeleteHomeService(int id, CancellationToken cancellationToken)
            => await _houseWorkRepository.DeleteHomeService(id, cancellationToken);

        public async Task<List<SummHouseWorkDto>> GetAll(CancellationToken cancellationToken)
            => await _houseWorkRepository.GetHomeServices(cancellationToken);

        public HouseWork GetById(int id)
            => _houseWorkRepository.GetHomeServiceById(id);

        public async Task<SummHouseWorkDto> GetServiceByChildId(int id, CancellationToken cancellationToken)
            => await _houseWorkRepository.GetServiceByChildId(id, cancellationToken);

        public async Task<SummHouseWorkDto> GetServiceById(int id, CancellationToken cancellationToken)
            =>await _houseWorkRepository.GetServiceById(id, cancellationToken);
        public async Task<int> GetServiceCount(int categoryId)
            => await _houseWorkRepository.GetServiceCount(categoryId);

        public UpdateHouseWork GetServiceDto(int id)
            => _houseWorkRepository.GetServiceDto(id);

        public async Task<List<SummHouseWorkDto>> GetServicesByChildId(int id, CancellationToken cancellationToken)
            => await _houseWorkRepository.GetServicesByChildId(id, cancellationToken);

        public async Task<List<SummHouseWorkDto>> GetServicesById(int id ,CancellationToken cancellationToken)
            => await _houseWorkRepository.GetServicesById(id , cancellationToken);

        public List<SummHouseWorkDto> GetServicesById()
            => _houseWorkRepository.GetServicesById();

        public async Task<Result> SoftDeleteHomeService(HouseWork service, CancellationToken cancellationToken)
            => await _houseWorkRepository.SoftDeleteHomeService(service, cancellationToken);

        public async Task<Result> UpdateHomeService(UpdateHouseWork service, CancellationToken cancellationToken)
            => await _houseWorkRepository.UpdateHomeService(service, cancellationToken);
    }
}
