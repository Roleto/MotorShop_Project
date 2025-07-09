namespace MotorShop_Project.Model.Classes
{
    public class BrandModel
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string? Type { get; set; }
        public decimal Price { get; set; }

        public ICollection<Extras> Extras { get; set; } = new List<Extras>();

        public override string ToString()
        {
            return $"Model: Id={Id}, BrandId={BrandId}, Name={Name}, Type={Type}, Price={Price:C}";
        }
    }

}
