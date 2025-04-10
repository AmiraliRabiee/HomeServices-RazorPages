using App.Domain.Core.Dto.HomeService;

namespace App.Domain.Core.Contracts.Dapper.Repository
{
    public interface IHouseWorkDapperRepository
    {
        Task<List<SummHouseWorkDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
