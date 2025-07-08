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
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Spectre.Console;
using static System.Formats.Asn1.AsnWriter;
using MotorShop_Project.Classes;

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
                    services.AddDbContext<MotorShopDbContext>(options =>
                     options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MotorShopDb;Trusted_Connection=True;"));


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

            Menu.StartMenu(scope);
        }
        public class MappingProfile : AutoMapper.Profile
        {
            public MappingProfile()
            {
                CreateMap<Brand, BrandEntity>().ReverseMap();

                CreateMap<BrandModel, ModelEntity>().ReverseMap();

                CreateMap<Order, OrderEntity>().ReverseMap();

                CreateMap<Extras, ExtrasEntity>().ReverseMap();
            }
        }

    }
}
