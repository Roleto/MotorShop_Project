using Microsoft.EntityFrameworkCore;
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
        }
        public async Task CreateAsync(ExtrasEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            await context.Extras.AddAsync(item);
        }

        public ExtrasEntity Read(int id)
        {
            var readItem = ReadAll().FirstOrDefault(x => x.Id == id);

            if (readItem == null)
                throw new KeyNotFoundException($"No Extras found with Id {id}");

            return readItem;
        }
        public async Task<ExtrasEntity> ReadAsync(int id)
        {
            var readItem = (await ReadAllAsync()).FirstOrDefault(x => x.Id == id);

            if (readItem == null)
                throw new KeyNotFoundException($"No Extras found with Id {id}");

            return readItem;
        }

        public void Update(ExtrasEntity item)
        {
            context.Extras.Update(item);
        }

        public void Delete(ExtrasEntity item)
        {
            context.Extras.Remove(item);
        }

        public DbSet<ExtrasEntity> ReadAll()
        {
            return context.Set<ExtrasEntity>();
        }
        public async Task<IEnumerable<ExtrasEntity>> ReadAllAsync()
        {
            return await context.Set<ExtrasEntity>().ToListAsync();
        }
    }
}
