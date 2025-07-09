using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace MotorShop_Project.Data.DBContext
{
    public class MotorShopDbContextFactory : IDesignTimeDbContextFactory<MotorShopDbContext>
    {
        public MotorShopDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MotorShopDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MotorShopDb;Trusted_Connection=True;");


            return new MotorShopDbContext(optionsBuilder.Options);
        }
    }
}
