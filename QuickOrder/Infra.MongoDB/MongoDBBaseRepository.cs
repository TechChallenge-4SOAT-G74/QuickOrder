using Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using static Infra.MongoDB.DbConnectionModel;

namespace Infra.MongoDB
{
    public class MongoDbConnection<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoDbConnection(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _collection = database.GetCollection<T>(collectionName);
        }

        public IMongoCollection<T> Collection => _collection;
    }

    public class MongoDBBaseRepository<T> where T : EntityBase
    {
        protected readonly IMongoCollection<T> _collection;

        public MongoDBBaseRepository(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<T>(
                databaseSettings.Value.CollectionName);
        }

        public async Task<List<T>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<T?> GetAsync(Guid id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(T newBook) =>
            await _collection.InsertOneAsync(newBook);

        public async Task UpdateAsync(Guid id, T updatedBook) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(Guid id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }

}
