    using MotorShop_Project.Data.DBContext;
    using MotorShop_Project.Data.Entities;
    using MotorShop_Project.Repository.Interface;

    namespace MotorShop_Project.Repository.Classes
    {
        public class UnitOfWork : IUnitOfWork
        {
            private readonly MotorShopDbContext context;

            public UnitOfWork(MotorShopDbContext context)
            {
                this.context = context;
                Brands = new BrandRepository(context);
                Models = new ModelRepository(context);
                Extras = new ExtrasRepository(context);
                Orders = new OrderRepository(context);
            }

            public IRepository<BrandEntity> Brands  { get; }

            public IRepository<ModelEntity> Models { get; }

            public IRepository<ExtrasEntity> Extras { get; }

            public IRepository<OrderEntity> Orders { get; }

            public void Complete()
            {
                context.SaveChanges();
            }

            public async Task CompleteAsync()
            {
                await context.SaveChangesAsync();
            }

            public void Dispose()
            {
                context.Dispose();
            }
        }
    }
