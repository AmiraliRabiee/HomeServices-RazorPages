using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites;
using App.Domain.Core.Entites.Result;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IHomeServiceRepository
    {
        Task<Result> CreateService(SummHomeServiceDto service, CancellationToken cancellationToken);
        Task<Result> DeleteHomeService(HomeService service, CancellationToken cancellationToken);
        Task<Result> UpdateHomeService(HomeService service, CancellationToken cancellationToken);
        Task<HomeService> GetHomeServiceById(int id, CancellationToken cancellationToken);
        Task<List<SummHomeServiceDto>> GetHomeService();
    }
}
