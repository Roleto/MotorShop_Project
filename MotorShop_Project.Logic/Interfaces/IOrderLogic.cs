using MotorShop_Project.Model.Classes;

namespace MotorShop_Project.Logic.Interfaces
{
    public interface IOrderLogic : ILogic<Order>
    {
        IEnumerable<Brand> GetBrands { get; }
        IEnumerable<BrandModel> GetModels { get; }
        void nonCrud1();
        void nonCrud2();
        void nonCrud3();
    }
}
