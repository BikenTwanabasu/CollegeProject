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
        [HttpGet]
        public IActionResult VendorRegistration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult VendorRegistration(Vendor vendor)
        {
            var a=_services.InsertVendor(vendor);
            return Json(a);

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
