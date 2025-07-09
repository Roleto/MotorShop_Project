using MotorShop_Project.Data.Entities;

namespace MotorShop_Project.Repository.Interface
{
    public interface IUnitOfWork
    {
        IRepository<BrandEntity> Brands { get; }
        IRepository<ModelEntity> Models { get; }
        IRepository<ExtrasEntity> Extras { get; }
        IRepository<OrderEntity> Orders { get; }

        void Complete();
        Task CompleteAsync();

    }

}
