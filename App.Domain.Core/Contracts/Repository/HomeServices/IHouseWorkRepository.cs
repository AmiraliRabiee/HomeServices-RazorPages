using App.Domain.Core.Dto.Dashboard;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.Core.Contracts.Repository.HomeServices
{
    public interface IHouseWorkRepository
    {
        Task<Result> CreateService(SummHouseWorkDto service, CancellationToken cancellationToken);
        Task<Result> DeleteHomeService(int id, CancellationToken cancellationToken);
        Task<Result> SoftDeleteHomeService(HouseWork service, CancellationToken cancellationToken);
        Task<Result> UpdateHomeService(UpdateHouseWork service, CancellationToken cancellationToken);
        HouseWork GetHomeServiceById(int id);
        Task<List<SummHouseWorkDto>> GetHomeServices(CancellationToken cancellationToken);
        UpdateHouseWork GetServiceDto(int id);
        Task<List<SummHouseWorkDto>> GetServicesById(int id, CancellationToken cancellationToken);
        List<SummHouseWorkDto> GetServicesById();
        Task<int> GetServiceCount(int categoryId);
        Task<List<SummHouseWorkDto>> GetServicesByChildId(int id, CancellationToken cancellationToken);
        Task<SummHouseWorkDto> GetServiceByChildId(int id, CancellationToken cancellationToken);
        Task<CategoryDto> GetCategoryByServiceId(int id, CancellationToken cancellationToken);
        Task<SummHouseWorkDto> GetServiceById(int id, CancellationToken cancellationToken);
    }
}
