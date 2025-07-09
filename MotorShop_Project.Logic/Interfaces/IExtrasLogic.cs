using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Model.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorShop_Project.Logic.Interfaces
{
    public interface IExtrasLogic : ILogic<Extras>
    {
        IEnumerable<BrandModel> GetModels { get; }
        void nonCrud1();
        void nonCrud2();
        void nonCrud3();
    }
}
