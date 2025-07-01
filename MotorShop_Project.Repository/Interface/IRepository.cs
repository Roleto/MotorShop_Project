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
        T Read(int id);
        void Update(T item);
        void Delete(T item);
        IEnumerable<T> ReadAll();
    }
}
