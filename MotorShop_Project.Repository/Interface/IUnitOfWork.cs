using MotorShop_Project.Data.Entities;
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
        IRepository<BrandEntity> Brands { get; }
        IRepository<ModelEntity> Models { get; }
        IRepository<ExtrasEntity> Extras { get; }
        IRepository<OrderEntity> Orders { get; }

        void Complete();
    }

}
