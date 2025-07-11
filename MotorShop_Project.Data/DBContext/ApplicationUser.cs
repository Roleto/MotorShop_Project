using Microsoft.AspNetCore.Identity;

namespace MotorShop_Project.Data.DBContext
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}