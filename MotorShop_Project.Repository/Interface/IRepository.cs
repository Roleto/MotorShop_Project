using Microsoft.EntityFrameworkCore;

namespace MotorShop_Project.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        Task CreateAsync(T item);
        T Read(int id);
        Task<T> ReadAsync(int id);
        void Update(T item);
        void Delete(T item);
        DbSet<T> ReadAll();
        Task<IEnumerable<T>> ReadAllAsync();

        Task<T> ReadNoTracking(int id);
        Task<IEnumerable<T>> ReadAllNoTracking();
    }
}
