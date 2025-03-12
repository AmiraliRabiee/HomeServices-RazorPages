namespace App.Infrastructure.Dapper
{
    public interface ICityDapperRepository
    {
        Task<List<City>> GetCitiesAsync(CancellationToken cancellationToken);
    }
}
