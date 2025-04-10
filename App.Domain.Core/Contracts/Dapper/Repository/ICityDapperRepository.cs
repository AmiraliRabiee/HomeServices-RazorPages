namespace App.Domain.Core.Contracts.Dapper.Repository
{
    public interface ICityDapperRepository
    {
        Task<List<City>> GetCitiesAsync(CancellationToken cancellationToken);
    }
}
