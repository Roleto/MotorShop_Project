﻿using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Data.DBContext;
using MotorShop_Project.Data.Entities;
using MotorShop_Project.Repository.Interface;

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

        public IEnumerable<ExtrasEntity> ReadAll()
        {
            return context.Set<ExtrasEntity>().Include(e => e.Model);
        }
        public async Task<IEnumerable<ExtrasEntity>> ReadAllAsync()
        {
            return await context.Set<ExtrasEntity>().Include(e => e.Model).ToListAsync();
        }

        public async Task<ExtrasEntity> ReadNoTracking(int id)
        {
            return (await ReadAllNoTracking()).FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<ExtrasEntity>> ReadAllNoTracking()
        {
            return await context.Set<ExtrasEntity>().AsNoTracking().Include(e => e.Model).ToListAsync();
        }
    }
}
