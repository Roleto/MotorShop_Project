using System.ComponentModel.DataAnnotations;

namespace MotorShop_Project.Model.Classes
{
    public class BrandModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Brand Id")]
        public int BrandId { get; set; }
        [Display(Name = "Brand")]
        public Brand? Brand { get; set; }
        [Display(Name = "Model Name")]
        public string Name { get; set; } = null!;
        [Display(Name = "Model Type")]
        public string? Type { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        public ICollection<Extras> Extras { get; set; } = new List<Extras>();

        public override string ToString()
        {
            return $"Model: Id={Id}, BrandId={BrandId}, Name={Name}, Type={Type}, Price={Price:C}";
        }
    }

}
