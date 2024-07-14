using CookBook.Repositories.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Repositories {
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity {
        private readonly IMongoDbContext _context;
        private IMongoCollection<T> _collection;

        public BaseRepository(IMongoDbContext context) {
            _context = context;
            _collection = _context.GetCollection<T>(typeof(T).Name);
        }

        public async Task Create(T entity) {
            await _collection.InsertOneAsync(entity);
        }
        //getter
        public async Task<T> Read(string id) {
            var objectId = new ObjectId(id);
            return await _collection.FindAsync(Builders<T>.Filter.Eq("_id", objectId)).Result.FirstOrDefaultAsync();
        }

        public async Task<List<T>> Read() {
            var result = await _collection.FindAsync(Builders<T>.Filter.Empty);
            return await result.ToListAsync();
        }

        public async Task Update(T entity) {
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", entity.Id), entity);
        }

        public async Task Delete(string id) {
            var objectId = new ObjectId(id);
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", objectId));
        }


    }
}
