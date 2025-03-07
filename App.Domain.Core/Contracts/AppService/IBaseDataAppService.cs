using App.Domain.Core.Dto.Dashboard;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IBaseDataAppService
    {
        List<City> GetCities();
        Task<StatisticsCustomerDto> GetStatisticData(int id, CancellationToken cancellationToken);
        Task<AmountsDto> GetAmountsData(int id, CancellationToken cancellationToken);
    }
}
