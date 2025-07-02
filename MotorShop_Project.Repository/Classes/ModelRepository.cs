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
    public class ModelRepository : IRepository<ModelEntity>
    {
        private MotorShopDbContext context;

        public ModelRepository(MotorShopDbContext context)
        {
            this.context = context;
        }

        public void Create(ModelEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            context.Models.Add(item);
            context.SaveChanges();
        }
        public ModelEntity Read(int id)
        {
            var readItem = ReadAll().FirstOrDefault(x => x.Id == id);

            if (readItem == null)
                throw new KeyNotFoundException($"No Model found with Id {id}");

            return readItem;
        }
        public void Update(ModelEntity item)
        {
            var oldItem = Read(item.Id);

            oldItem.BrandId = item.BrandId;
            oldItem.Name = item.Name;
            oldItem.Type = item.Type;
            oldItem.Price = item.Price;

            context.SaveChanges();
        }

        public void Delete(ModelEntity item)
        {
            context.Models.Remove(item);
            context.SaveChanges();
        }


        public IEnumerable<ModelEntity> ReadAll()
        {
            return context.Set<ModelEntity>();
        }

    }
}
