using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity.UI;
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
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            // Add EF Core
            builder.Services.AddDbContext<MotorShopDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Add Auto Mapper
            builder.Services.AddAutoMapper(typeof(Program));
           
            // Add Logic Layer
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            builder.Services.AddScoped<IBrandLogic, BrandLogic>();
            builder.Services.AddScoped<IModelLogic, ModelLogic>();
            builder.Services.AddScoped<IExtrasLogic, ExtrasLogic>();
            builder.Services.AddScoped<IOrderLogic, OrderLogic>();
            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            })
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<MotorShopDbContext>();


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
            using (var scope = app.Services.CreateScope())
            {
                await SeedRoles(scope.ServiceProvider);
            }
            app.Run();
        }

        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
