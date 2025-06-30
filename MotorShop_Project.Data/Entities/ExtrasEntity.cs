using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorShop_Project.Data.Entities
{
    public class ExtrasEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ModelId { get; set; }

        [ForeignKey(nameof(ModelId))]
        public ModelEntity Model { get; set; }

        [Required]
        [MaxLength(24)]
        public string Name { get; set; }

        [MaxLength(24)]
        public string Type { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }
    }
}
