using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorShop_Project.Data.Entities
{

    public class BrandEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string? Alt { get; set; }

        public byte[]? Image { get; set; }

        public string? ContentType { get; set; }
        public ICollection<ModelEntity> Models { get; set; }
    }

}
