using CookBook.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CookBook.Api {
    public class MongoDbContext : IMongoDbContext { 
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public MongoDbContext(IOptions<DatabaseConnectionSettings> configuration) {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name) {
            return _db.GetCollection<T>(name);
        }
    }
}
