using MotorShop_Project.Data.DBContext;
using MotorShop_Project.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorShop_Project.Repository.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MotorShopDbContext context;

        public UnitOfWork(MotorShopDbContext context,
            IRepository<BrandRepository> brands,
            IRepository<ModelRepository> models,
            IRepository<ExtrasRepository> extras,
            IRepository<OrderRepository> orders)
        {
            this.context = context;
            Brands = brands;
            Models = models;
            Extras = extras;
            Orders = orders;
        }

        public IRepository<BrandRepository> Brands { get; }

        public IRepository<ModelRepository> Models { get; }

        public IRepository<ExtrasRepository> Extras { get; }

        public IRepository<OrderRepository> Orders { get; }



        public void Complete()
        {
            context.SaveChanges();
        }
    }
}
