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
    public class ExtrasRepository : IRepository<ExtrasEntity>
    {
        private MotorShopDbContext context;

        public ExtrasRepository(MotorShopDbContext context)
        {
            this.context = context;
        }

        public void Create(ExtrasEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            context.Extras.Add(item);
            context.SaveChanges();
        }

        public ExtrasEntity Read(int id)
        {
            var readItem = ReadAll().FirstOrDefault(x => x.Id == id);

            if (readItem == null)
                throw new KeyNotFoundException($"No Extras found with Id {id}");

            return readItem;
        }

        public void Update(ExtrasEntity item)
        {
            var oldItem = Read(item.Id);

            oldItem.ModelId = item.ModelId;
            oldItem.Name = item.Name;
            oldItem.Type = item.Type;
            oldItem.Price = item.Price;
            oldItem.Description = item.Description;

            context.SaveChanges();
        }

        public void Delete(ExtrasEntity item)
        {
            context.Extras.Remove(item);
            context.SaveChanges();
        }

        public IEnumerable<ExtrasEntity> ReadAll()
        {
            return context.Set<ExtrasEntity>();
        }
    }
}
