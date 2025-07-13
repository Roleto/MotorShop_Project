using System.ComponentModel.DataAnnotations;

namespace MotorShop_Project.Model.Classes
{
    public class Order
    {
        [Display(Name = "Order Id")]

        public int Id { get; set; }
        [Display(Name = "Brand Id")]
        public int BrandId { get; set; }
        [Display(Name = "Brand")]
        public Brand? Brand { get; set; } = null;

        [Display(Name = "Model Id")]
        public int ModelId { get; set; }
        [Display(Name = "Model")]
        public BrandModel? Model { get; set; } = null;

        [Display(Name = "User Id")]
        public string UserId { get; set; } = "";

        [Display(Name = "Order Time")]
        public DateTime OrderTime { get; set; }

        [Display(Name = "Has Extras")]
        public bool HasExtras { get; set; }

        public ICollection<Extras> Extras { get; set; } = new List<Extras>();

        public List<int> SelectedExtraIds { get; set; } = new List<int>();

        public override string ToString()
        {
            return $"Order: Id={Id}, BrandId={BrandId}, ModelId={ModelId}, OrderTime={OrderTime}, HasExtras={HasExtras}";
        }
    }

}
