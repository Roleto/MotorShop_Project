using Microsoft.EntityFrameworkCore;
using MotorShop_Project.Data.DBContext;
using MotorShop_Project.Logic.Classes;
using MotorShop_Project.Logic.Interfaces;
using MotorShop_Project.Repository.Classes;
using MotorShop_Project.Repository.Interface;
namespace Motorshop_Project.MVC

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            // Add EF Core
            builder.Services.AddDbContext<MotorShopDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //
            builder.Services.AddAutoMapper(typeof(Program));

            // Add Logic Layer
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            builder.Services.AddScoped<IBrandLogic, BrandLogic>();
            builder.Services.AddScoped<IModelLogic, ModelLogic>();
            builder.Services.AddScoped<IExtrasLogic, ExtrasLogic>();
            builder.Services.AddScoped<IOrderLogic, OrderLogic>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
