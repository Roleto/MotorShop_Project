using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MotorShop_Project.Data.DBContext;
using MotorShop_Project.Repository.Interface;
using MotorShop_Project.Repository.Classes;
using MotorShop_Project.Logic.Interfaces;
using MotorShop_Project.Logic.Classes;
using AutoMapper;
using MotorShop_Project.Data.Entities;
using MotorShop_Project.Model.Classes;

namespace MotorShop_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    // DbContext
                    services.AddDbContext<MotorShopDbContext>();

                    // Unit of Work
                    services.AddScoped<IUnitOfWork, UnitOfWork>();

                    // Logic
                    services.AddScoped<IBrandLogic, BrandLogic>();
                    services.AddScoped<IModelLogic, ModelLogic>();
                    services.AddScoped<IOrderLogic, OrderLogic>();
                    services.AddScoped<IExtrasLogic, ExtrasLogic>();

                    // AutoMapper
                    services.AddAutoMapper(typeof(MappingProfile));
                })
                .Build();

            using var scope = host.Services.CreateScope();
            var logic = scope.ServiceProvider.GetRequiredService<IBrandLogic>();
        }
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandEntity>();
            CreateMap<BrandEntity, Brand>();

            CreateMap<BrandModel, ModelEntity>();
            CreateMap<ModelEntity, BrandModel>();

            CreateMap<Order, OrderEntity>();
            CreateMap<OrderEntity, Order>();

            CreateMap<Extras, ExtrasEntity>();
            CreateMap<ExtrasEntity, Extras>();
        }
    }

}
