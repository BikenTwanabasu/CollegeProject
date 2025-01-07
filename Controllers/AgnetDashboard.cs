using CollegeProject.RepoClass;
using Microsoft.AspNetCore.Mvc;

namespace CollegeProject.Controllers
{
    public class AgnetDashboard : Controller
    {
        public IActionResult Index()
        {
            var a = HttpContext.GetClaimsData();
            ViewBag.ID = a.Id;
            ViewBag.Name = a.Name;
            return View();

        }

    }
}
