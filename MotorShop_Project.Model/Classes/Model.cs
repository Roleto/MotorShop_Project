﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorShop_Project.Model.Classes
{
    public class Model
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string? Type { get; set; }
        public decimal Price { get; set; }

        public ICollection<Extra> Extras { get; set; } = new List<Extra>();
    }

}
