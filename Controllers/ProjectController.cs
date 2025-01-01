using CollegeProject.Models;
using CollegeProject.RepoClass;
using Microsoft.AspNetCore.Mvc;

namespace CollegeProject.Controllers
{
    public class ProjectController : Controller
    {
        private IServices _services;

        public ProjectController(IServices services)
        {
            _services = services;
        }
        
        public IActionResult VendorRegistration(Vendor vendor)
        {
            
            var a=_services.InsertVendor(vendor);
            if (a)
            {
                return Json(a);
            }
            return View();

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
