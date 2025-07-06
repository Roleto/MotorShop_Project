using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorShop_Project.Model.Classes
{
    public class Extras
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public BrandModel Model { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string? Type { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public override string ToString()
        {
            return $"Extras: Id={Id}, ModelId={ModelId}, Name={Name}, Type={Type}, Price={Price:C}, Description={Description}";
        }
    }

}
