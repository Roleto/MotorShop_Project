using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorShop_Project.Data.Entities
{
    public class ModelEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public BrandEntity Brand { get; set; }

        [Required]
        [MaxLength(24)]
        public string Name { get; set; }

        [MaxLength(24)]
        public string Type { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public ICollection<ExtrasEntity> Extras { get; set; }
    }
}
