using App.Domain.Core.Dto.Dashboard;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IBaseDataAppService
    {
        Task<List<City>> GetCitiesAsync(CancellationToken cancellationToken);
        Task<StatisticsCustomerDto> GetStatisticData(int id, CancellationToken cancellationToken);
        Task<AmountsDto> GetAmountsData(int id, CancellationToken cancellationToken);
        Task<StatisticsExpertDto> GetStatisticsExpert(int id, CancellationToken cancellationToken);
    }
}
