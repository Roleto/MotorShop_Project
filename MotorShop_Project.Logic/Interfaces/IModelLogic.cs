using MotorShop_Project.Model.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
