using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotorShop_Project.Data.DBContext;

namespace Motorshop_Project.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
