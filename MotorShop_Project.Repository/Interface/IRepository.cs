using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorShop_Project.Repository.Interface
{
    public interface IRepository<T>
    {
        void Create(T item);
        Task CreateAsync(T item);
        T Read(int id);
        Task<T> ReadAsync(int id);
        void Update(T item);
        void Delete(T item);
        IEnumerable<T> ReadAll();
        Task<IEnumerable<T>> ReadAllAsync();

        //T ReadNoTracking(int id);
        //IEnumerable<T> ReadAllNoTracking();
    }
}
