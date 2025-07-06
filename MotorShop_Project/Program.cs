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
                    //options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MotorShopDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));


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

            //var item1 = new Brand() { Alt = "proba1", ImgUrl = "képUrl1", Name = "teszt1" };
            //var item2 = new Brand() { Alt = "proba2", ImgUrl = "képUrl2", Name = "teszt2" };
            //logic.Create(item1);
            //logic.Create(item2);
            //var items = logic.ReadAll();
            //foreach (var item in items)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            Menu();
        }

        static void Menu()
        {
            bool running = true;

            while (running)
            {
                var mainSelection = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]Főmenü - Válassz egy opciót:[/]")
                        .AddChoices(new[]
                        {
                        "Brand", "Model", "Extras", "Order", "Instructions", "Exit"
                        }));

                switch (mainSelection)
                {
                    case "Brand":
                        HandleEntityMenu("Brand");
                        break;
                    case "Model":
                        HandleEntityMenu("Model");
                        break;
                    case "Extras":
                        HandleEntityMenu("Extras");
                        break;
                    case "Order":
                        HandleEntityMenu("Order");
                        break;
                    case "Instructions":
                        ShowInstructions();
                        break;
                    case "Exit":
                        running = false;
                        break;
                }
            }

            AnsiConsole.MarkupLine("[green]Kilépés...[/]");
        }

        static void HandleEntityMenu(string entityName)
        {
            while (true)
            {
                var subSelection = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title($"[blue]{entityName} menü - válassz egy műveletet:[/]")
                        .AddChoices(new[]
                        {
                        "Create", "Read", "Update", "Delete",
                        "NonCrud1", "NonCrud2", "NonCrud3",
                        "Back"
                }));

                if (subSelection == "Back")
                    break;

                AnsiConsole.MarkupLine($"[green]{entityName} - {subSelection} végrehajtva (még nincs implementálva)[/]");
            }
        }

        static void ShowInstructions()
        {
            AnsiConsole.MarkupLine("[bold yellow]Használati útmutató:[/]");
            AnsiConsole.MarkupLine("- Válassz entitást a főmenüből (Brand, Model, Extras, Order)");
            AnsiConsole.MarkupLine("- Ezután válassz egy CRUD vagy Non-CRUD műveletet");
            AnsiConsole.MarkupLine("- A Back menüponttal visszatérhetsz a főmenübe\n");
        }
    }
    public class MappingProfile : AutoMapper.Profile
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
