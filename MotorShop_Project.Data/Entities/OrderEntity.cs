using MotorShop_Project.Data.DBContext;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string UserId { get; set; }
        public DateTime OrderTime { get; set; } = DateTime.UtcNow;

        public bool HasExtras{ get; set; } 

        public ICollection<ExtrasEntity> Extras { get; set; }

        [NotMapped]
        public List<int> SelectedExtraIds { get; set; } = new List<int>();

    }
}
