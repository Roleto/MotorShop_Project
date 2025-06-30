using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorShop_Project.Model.Classes
{
    public class Extra
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string? Type { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

}
