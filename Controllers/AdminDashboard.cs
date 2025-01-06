using Microsoft.AspNetCore.Mvc;

namespace CollegeProject.Controllers
{
    public class AdminDashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
