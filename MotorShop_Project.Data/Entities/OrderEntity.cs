using System.ComponentModel.DataAnnotations;

namespace MotorShop_Project.Data.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }

        public int BrandId { get; set; }
        public BrandEntity Brand { get; set; }

        public int ModelId { get; set; }
        public ModelEntity Model { get; set; }

        public DateTime OrderTime { get; set; } = DateTime.UtcNow;

        public bool HasExtras{ get; set; } 

        public ICollection<ExtrasEntity> Extras { get; set; }
    }
}
