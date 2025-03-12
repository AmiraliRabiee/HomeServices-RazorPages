using App.Domain.Core.Dto.HomeService;

namespace App.Infrastructure.Dapper
{
    public interface IHouseWorkDapperRepository
    {
        Task<List<SummHouseWorkDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
