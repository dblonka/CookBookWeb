using MongoDB.Driver;

namespace CookBook.Repositories
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
