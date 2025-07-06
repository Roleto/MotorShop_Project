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
        public BrandModel Model { get; set; } = null!;

        public DateTime OrderTime { get; set; }

        public bool HasExtras { get; set; }

        public ICollection<Extras> Extras { get; set; } = new List<Extras>();

        public override string ToString()
        {
            return $"Order: Id={Id}, BrandId={BrandId}, ModelId={ModelId}, OrderTime={OrderTime}, HasExtras={HasExtras}, Extras={Extras}";
        }
    }

}
