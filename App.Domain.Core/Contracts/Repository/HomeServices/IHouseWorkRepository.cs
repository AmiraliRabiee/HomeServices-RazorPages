using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites;
using App.Domain.Core.Entites.Result;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IHouseWorkRepository
    {
        Task<Result> CreateService(HouseWork service, CancellationToken cancellationToken);
        Task<Result> DeleteHomeService(HouseWork work, CancellationToken cancellationToken);
        Task<Result> SoftDeleteHomeService(HouseWork service, CancellationToken cancellationToken);
        Task<Result> UpdateHomeService(HouseWork service, CancellationToken cancellationToken);
        Task<HouseWork> GetHomeServiceById(int id, CancellationToken cancellationToken);
        Task<List<SummHouseWorkDto>> GetHomeService();
    }
}
