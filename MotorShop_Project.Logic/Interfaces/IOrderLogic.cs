using MotorShop_Project.Model.Classes;
using System.Collections;

namespace MotorShop_Project.Logic.Interfaces
{
    public interface IOrderLogic : ILogic<Order>
    {
        IEnumerable<Brand> GetBrands { get; }
        IEnumerable<BrandModel> GetModels { get; }
        IEnumerable<Extras> GetExtras { get; }

        void nonCrud1();
        void nonCrud2();
        void nonCrud3();
        Task<Order> ReadAsNoTrackingAsync(int id);
    }
}
