using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace MotorShop_Project.Data.DBContext
{
    public class MotorShopDbContextFactory : IDesignTimeDbContextFactory<MotorShopDbContext>
    {
        public MotorShopDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MotorShopDbContext>();
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MotorShopDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MotorShopDb;Trusted_Connection=True;");


            return new MotorShopDbContext(optionsBuilder.Options);
        }
    }
}
