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
        public string? ImgUrl { get; set; } 
        
        public ICollection<BrandModel> Models { get; set; } = new List<BrandModel>();

        public override string ToString()
        {
            return $"Brand: Id={Id}, Name={Name}, Alt={Alt}, ImgUrl={ImgUrl}";
        }
    }

}
