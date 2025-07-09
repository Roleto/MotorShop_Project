using System.ComponentModel.DataAnnotations;

namespace MotorShop_Project.Model.Classes
{
    public class Extras
    {
        [Display(Name = "Extras Id")]

        public int Id { get; set; }
        [Display(Name = "Model Id")]
        public int ModelId { get; set; }
        [Display(Name = "Model")]
        public BrandModel Model { get; set; } = null!;

        [Display(Name = "Extra Name")]
        public string Name { get; set; } = null!;
        [Display(Name = "Extra Type")]
        public string? Type { get; set; }
        [Display(Name = "Extra Price")]
        public decimal Price { get; set; }
        [Display(Name = "Extra Description")]
        public string? Description { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public override string ToString()
        {
            return $"Extras: Id={Id}, ModelId={ModelId}, Name={Name}, Type={Type}, Price={Price:C}, Description={Description}";
        }
    }

}
