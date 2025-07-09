using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Data.DBContext;
using MotorShop_Project.Data.Entities;
using MotorShop_Project.Repository.Interface;

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
        }
        public async Task CreateAsync(ModelEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            await context.Models.AddAsync(item);
        }
        public ModelEntity Read(int id)
        {
            var readItem = ReadAll().FirstOrDefault(x => x.Id == id);

            if (readItem == null)
                throw new KeyNotFoundException($"No Model found with Id {id}");

            return readItem;
        }

        public async Task<ModelEntity> ReadAsync(int id)
        {
            var readItem = (await ReadAllAsync()).FirstOrDefault(x => x.Id == id);

            if (readItem == null)
                throw new KeyNotFoundException($"No Model found with Id {id}");

            return readItem;
        }
        public void Update(ModelEntity item)
        {
            context.Models.Update(item);
        }

        public void Delete(ModelEntity item)
        {
            context.Models.Remove(item);
        }


        public DbSet<ModelEntity> ReadAll()
        {
            return context.Set<ModelEntity>();
        }
        public async Task<IEnumerable<ModelEntity>> ReadAllAsync()
        {
            return await context.Set<ModelEntity>().Include(m => m.Brand).ToListAsync();
        }
    }
}
