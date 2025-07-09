using MotorShop_Project.Model.Classes;

namespace MotorShop_Project.Logic.Interfaces
{
    public interface IModelLogic : ILogic<BrandModel>
    {
        IEnumerable<Brand> GetBrands { get; }
        void nonCrud1();
        void nonCrud2();
        void nonCrud3();
    }
}
