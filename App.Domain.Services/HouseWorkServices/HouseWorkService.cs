using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites;
using App.Domain.Core.Entites.Result;

namespace App.Domain.Services
{
    public class HouseWorkService(IHouseWorkRepository _houseWorkRepository) : IHouseWorkService
    {
        public Task<Result> CreateService(HouseWork service, CancellationToken cancellationToken)
            => _houseWorkRepository.CreateService(service, cancellationToken);

        public Task<Result> DeleteHomeService(HouseWork work, CancellationToken cancellationToken)
            => _houseWorkRepository.DeleteHomeService(work, cancellationToken);

        public Task<List<SummHouseWorkDto>> GetAll()
            => _houseWorkRepository.GetHomeService();

        public Task<HouseWork> GetById(int id, CancellationToken cancellationToken)
            => _houseWorkRepository.GetHomeServiceById(id, cancellationToken);

        public Task<Result> SoftDeleteHomeService(HouseWork service, CancellationToken cancellationToken)
            => _houseWorkRepository.SoftDeleteHomeService(service, cancellationToken);

        public Task<Result> UpdateHomeService(HouseWork service, CancellationToken cancellationToken)
            => _houseWorkRepository.UpdateHomeService(service, cancellationToken);
    }
}
