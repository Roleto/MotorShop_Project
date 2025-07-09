using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorShop_Project.Logic.Interfaces
{
    public interface ILogic<T> where T : class
    {
            void Create(T item);
            Task CreateAsync(T item);
            T Read(int id);
            Task<T> ReadAsync(int id);
            void Update(T item);
            Task UpdateAsync(T item);
            void Delete(T item);
            Task DeleteAsync(T item);
            DbSet<T> ReadAll();
            Task<IEnumerable<T>> ReadAllAsync();

    }
}
