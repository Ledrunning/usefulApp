using Useful.ForecastDomain.Entities;

namespace Useful.ForecastRepository
{
    public interface ICosmosDbContext
    {
        void Initialize();

        Task InsertDataAsync(Weather item);

        Task<Weather> GetCollectionByKeyAsync(Guid companyId);
    }
}