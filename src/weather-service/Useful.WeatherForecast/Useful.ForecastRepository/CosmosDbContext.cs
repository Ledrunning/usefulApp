using MongoDB.Driver;

namespace Useful.ForecastRepository
{
    /// <summary>
    ///     Class provided Cosmos Db with Mongo Db API
    ///     For working with Azure Cosmo Db Emulator try next:
    ///     cd C:\Program Files\Azure Cosmos DB Emulator then .\CosmosDB.Emulator.exe /EnableMongoDbEndpoint
    /// </summary>
    public class CosmosDbContext : ICosmosDbContext
    {
        private IMongoClient _client;
        private readonly string _connectionString;
        private IMongoDatabase _database;
        private readonly string _databaseName;

        public CosmosDbContext(object configuration)
        {
            
        }

        /// <inheritdoc cref="ICosmosDbContext" />
        public void Initialize()
        {
            try
            {
                _client = new MongoClient(_connectionString);

                //Get or create database
                _database = _client.GetDatabase(_databaseName);
                //_database.CreateCollectionAsync(nameof());
            }
            catch (Exception e)
            {
                throw new Exception("Error database initializing: ", e);
            }
        }

        /// <inheritdoc cref="ICosmosDbContext" />
        public async Task InsertDataAsync(object item)
        {
            try
            {
                await GetCollection().InsertOneAsync(item);
                
            }
            catch (MongoCommandException e)
            {
                throw new MongoCommandException(e.ConnectionId, e.ErrorMessage, e.Result);
            }
        }
        
        /// <inheritdoc cref="ICosmosDbContext" />
        public async Task<object> GetCollectionByKeyAsync(Guid companyId)
        {
            object recordItem;
            try
            {
                //recordItem = await GetCollection().FindAsync(x => x.Id == companyId).Result.FirstAsync();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Error when get collection from DB by company id: {companyId}", e);
            }

            return null; // recordItem;
        }

        private IMongoCollection<object> GetCollection()
        {
            return _database.GetCollection<object>("");
        }
    }
}