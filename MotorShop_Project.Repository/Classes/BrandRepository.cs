using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Data.DBContext;
using MotorShop_Project.Data.Entities;
using MotorShop_Project.Repository.Interface;

namespace MotorShop_Project.Repository.Classes
{
    public class BrandRepository : IRepository<BrandEntity>
    {
        private MotorShopDbContext context;

        public BrandRepository(MotorShopDbContext context)
        {
            this.context = context;
        }

        public void Create(BrandEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if(item.Image != null && item.Image.Length == 0)
            {
                item.Image = null;
                item.ContentType = null;
            }

            context.Brands.Add(item);
        }
        public async Task CreateAsync(BrandEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            await context.Brands.AddAsync(item);
        }

        public BrandEntity Read(int id)
        {
            var readItem = ReadAll().FirstOrDefault(x => x.Id == id);

            if (readItem == null)
                throw new KeyNotFoundException($"No Brand found with Id {id}");

            return readItem;
        }
        public async Task<BrandEntity> ReadAsync(int id)
        {
            var readItem = (await ReadAllAsync()).FirstOrDefault(x => x.Id == id);

            if (readItem == null)
                throw new KeyNotFoundException($"No Brand found with Id {id}");

            return readItem;
        }

        public void Update(BrandEntity item)
        {
            context.Brands.Update(item);
        }

        public void Delete(BrandEntity item)
        {
            context.Brands.Remove(item);
        }
        public IEnumerable<BrandEntity> ReadAll()
        {
            return context.Set<BrandEntity>();
        }


        public async Task<IEnumerable<BrandEntity>> ReadAllAsync()
        {
            return await context.Set<BrandEntity>().ToListAsync();
        }

        // Nem kell ehez a projecthez csak hogy ne feljds el hogy van ilyen is
        //public IEnumerable<BrandEntity> ReadAllNoTracking()
        //{
        //    return context.Set<BrandEntity>().AsNoTracking();
        //}
        public async Task<BrandEntity> ReadNoTracking(int id)
        {
            return (await ReadAllNoTracking()).FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<BrandEntity>> ReadAllNoTracking()
        {
            return await context.Set<BrandEntity>().AsNoTracking().ToListAsync();
        }
    }
}
