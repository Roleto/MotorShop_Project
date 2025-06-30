using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorShop_Project.Model.Classes
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Alt { get; set; }
        public string? Img { get; set; } 
        
        public ICollection<Model> Models { get; set; } = new List<Model>();
    }

}
