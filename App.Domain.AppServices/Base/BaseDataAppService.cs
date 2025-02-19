using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.BaseEntities;

namespace App.Domain.AppServices.Base
{
    public class BaseDataAppService(IBaseDataService _baseDataService) : IBaseDataAppService
    {
        public Task<List<City>> GetCities(CancellationToken cancellationToken)
            => _baseDataService.GetCities(cancellationToken);
    }
}
