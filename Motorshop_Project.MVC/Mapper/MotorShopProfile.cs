using MotorShop_Project.Data.Entities;
using MotorShop_Project.Model.Classes;

namespace Motorshop_Project.MVC.Mapper
{
    public class MotorShopProfile: AutoMapper.Profile
    {
        public MotorShopProfile()
        {
            CreateMap<Brand, BrandEntity>().ReverseMap();

            CreateMap<BrandModel, ModelEntity>().ReverseMap();

            CreateMap<Order, OrderEntity>().ReverseMap();

            CreateMap<Extras, ExtrasEntity>().ReverseMap();
        }
    }
}
