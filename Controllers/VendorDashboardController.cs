using Microsoft.AspNetCore.Mvc;

namespace CollegeProject.Controllers
{
    public class VendorDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
