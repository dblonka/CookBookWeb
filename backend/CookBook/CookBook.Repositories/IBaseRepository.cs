using CookBook.Repositories.Models;

namespace CookBook.Repositories {
    public interface IBaseRepository<T> where T : Entity {
        Task Create(T entity);
        Task Delete(string id);
        Task<List<T>> Read();
        Task<T> Read(string id);
        Task Update(T entity);
    }
}