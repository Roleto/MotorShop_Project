namespace MotorShop_Project.Model.Classes
{
    public class Brand
    {
        public Brand()
        {
            
        }

        public Brand(string name, string? alt, byte[]? image)
        {
            Name = name;
            Alt = alt;
            Image = image;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Alt { get; set; }

        public byte[]? Image { get; set; }
        public string? ContentType { get; set; }

        public ICollection<BrandModel> Models { get; set; } = new List<BrandModel>();
        public bool HasImage { get => Image != null && Image.Length !=0; }
                                              
        public string? GetImgSrc
        {
            get
            {
                if (HasImage)
                {
                    var base64 = Convert.ToBase64String(Image);
                    return $"data:{ContentType};base64,{base64}";
                }
                return null;
            }
        }

        public override string ToString()
        {
            return $"Brand: Id={Id}, Name={Name}, Alt={Alt}, Image={this.HasImage}";
        }
    }

}
