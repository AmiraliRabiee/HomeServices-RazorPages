using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.Core.Contracts.Service.HomeServices
{
    public interface IHouseWorkService
    {
        Task<Result> CreateService(HouseWork service, CancellationToken cancellationToken);
        Task<Result> DeleteHomeService(HouseWork work, CancellationToken cancellationToken);
        Task<Result> SoftDeleteHomeService(HouseWork service, CancellationToken cancellationToken);
        Task<Result> UpdateHomeService(HouseWork service, CancellationToken cancellationToken);
        Task<HouseWork> GetById(int id, CancellationToken cancellationToken);
        Task<List<SummHouseWorkDto>> GetAll(CancellationToken cancellationToken);
    }
}
