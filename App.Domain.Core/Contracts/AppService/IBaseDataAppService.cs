using App.Domain.Core.Dto;
using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Entites.Service;
using App.Domain.Core.Entites.User;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IBaseDataAppService
    {
        Task<List<City>> GetCitiesAsync(CancellationToken cancellationToken);
        Task<StatisticsCustomerDto> GetStatisticData(int id, CancellationToken cancellationToken);
        Task<AmountsDto> GetAmountsData(int id, CancellationToken cancellationToken);
        Task<StatisticsExpertDto> GetStatisticsExpert(int id, CancellationToken cancellationToken);
        Task<List<SearchResultDto>> SearchExperts(string item);
        Task<List<SearchResultDto>> SearchHouseWorkAndCategries(string item);
    }
}
