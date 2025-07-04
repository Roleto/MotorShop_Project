using MotorShop_Project.Data.DBContext;
using MotorShop_Project.Data.Entities;
using MotorShop_Project.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorShop_Project.Repository.Classes
{
    public class OrderRepository : IRepository<OrderEntity>
    {
        private MotorShopDbContext context;

        public OrderRepository(MotorShopDbContext context)
        {
            this.context = context;
        }

        public void Create(OrderEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            context.Orders.Add(item);
            //context.SaveChanges();
        }

        public OrderEntity Read(int id)
        {
            var readItem = ReadAll().FirstOrDefault(x => x.Id == id);

            if (readItem == null)
                throw new KeyNotFoundException($"No Order found with Id {id}");

            return readItem;
        }

        public void Update(OrderEntity item)
        {
            //minden féle képpen tszteld le hogy müködik a deletet is!!!!!!!!!
            context.Orders.Update(item);

            //var oldItem = Read(item.Id);

            //oldItem.BrandId = item.BrandId;
            //oldItem.ModelId = item.ModelId;
            //oldItem.OrderTime = item.OrderTime;
            //oldItem.HasExtras = item.HasExtras;
            //oldItem.Extras = item.Extras;

            //context.SaveChanges();
        }

        public void Delete(OrderEntity item)
        {
            context.Orders.Remove(item);
            //context.SaveChanges();
        }

        public IEnumerable<OrderEntity> ReadAll()
        {
            return context.Set<OrderEntity>();
        }
    }
}
