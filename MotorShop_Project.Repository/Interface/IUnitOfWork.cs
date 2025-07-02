using MotorShop_Project.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorShop_Project.Repository.Interface
{
    public interface IUnitOfWork
    {
        IRepository<BrandRepository> Brands { get; }
        IRepository<ModelRepository> Models { get; }
        IRepository<ExtrasRepository> Extras { get; }
        IRepository<OrderRepository> Orders { get; }

        void Complete();
    }

}
