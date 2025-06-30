using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorShop_Project.Model.Classes
{
    public class Order
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;

        public int ModelId { get; set; }
        public Model Model { get; set; } = null!;

        public DateTime OrderTime { get; set; }

        public ICollection<Extra> Extras { get; set; } = new List<Extra>();
    }

}
