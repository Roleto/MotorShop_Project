using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Data.DBContext;
using MotorShop_Project.Data.Entities;
using MotorShop_Project.Repository.Interface;

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
        }

        public async Task CreateAsync(OrderEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            await context.Orders.AddAsync(item);
        }

        public OrderEntity Read(int id)
        {
            var readItem = ReadAll().FirstOrDefault(x => x.Id == id);

            if (readItem == null)
                throw new KeyNotFoundException($"No Order found with Id {id}");

            return readItem;
        }

        public async Task<OrderEntity> ReadAsync(int id)
        {
            var readItem = (await ReadAllAsync()).FirstOrDefault(x => x.Id == id);

            if (readItem == null)
                throw new KeyNotFoundException($"No Order found with Id {id}");

            return readItem;
        }

        public void Update(OrderEntity item)
        {
            context.Orders.Update(item);
        }

        public void Delete(OrderEntity item)
        {
            context.Orders.Remove(item);
        }

        public DbSet<OrderEntity> ReadAll()
        {
            return context.Set<OrderEntity>();
        }

        public async Task<IEnumerable<OrderEntity>> ReadAllAsync()
        {
            return await context.Set<OrderEntity>().Include(o => o.Brand).Include(o => o.Model).ToListAsync();
        }
    }
}
