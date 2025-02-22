using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.BaseEntities;

namespace App.Domain.AppServices.Base
{
    public class BaseDataAppService(IBaseDataService _baseDataService) : IBaseDataAppService
    {
        public List<City> GetCities()
            => _baseDataService.GetCities();
    }
}
