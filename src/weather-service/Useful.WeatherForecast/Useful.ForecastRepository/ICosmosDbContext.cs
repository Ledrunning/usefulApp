namespace Useful.ForecastRepository
{
    public interface ICosmosDbContext
    {
        void Initialize();

        Task InsertDataAsync(object item);

        Task<object> GetCollectionByKeyAsync(Guid companyId);
    }
}