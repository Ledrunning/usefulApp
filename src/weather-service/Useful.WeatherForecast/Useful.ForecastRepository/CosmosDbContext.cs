﻿using MongoDB.Driver;
using Useful.ForecastCommon.Contract;
using Useful.ForecastDomain.Entities;

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
        private readonly string? _connectionString;
        private IMongoDatabase _database;
        private readonly string? _databaseName;

        public CosmosDbContext(IForecastGatewayConfiguration configuration)
        {
            _connectionString = configuration.DbConnectionString;
            _databaseName = configuration.DbName;
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
        public async Task InsertDataAsync(Weather item)
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
        public async Task<Weather> GetCollectionByKeyAsync(Guid weatherId)
        {
            Weather recordItem;
            try
            {
                recordItem = await GetCollection().FindAsync(x => x.Id == weatherId).Result.FirstAsync();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Error when get collection from DB by company id: {weatherId}", e);
            }

            return recordItem;
        }

        //TODO need to put the name into the method !!!!!
        private IMongoCollection<Weather> GetCollection()
        {
            return _database.GetCollection<Weather>("");
        }
    }
}