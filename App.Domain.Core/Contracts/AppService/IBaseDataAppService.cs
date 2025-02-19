namespace App.Domain.Core.Contracts.AppService
{
    public interface IBaseDataAppService
    {
        Task<List<City>> GetCities(CancellationToken cancellationToken);

    }
}
