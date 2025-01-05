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
            
            var a=_services.RegisterVendor(vendor);
            if (a)
            {
                return Json(a);
            }
            return View();

        }
        public IActionResult AgentRegistration(Agent agent)
        {

            var a = _services.RegisterAgent(agent);
            if (a)
            {
                return Json(a);
            }
            return View();

        }
        
        public IActionResult OrderCreation(OrderAndStudentModel orderAndStudentModel)
        {

            var a = _services.OrderCreations(orderAndStudentModel);
            if (a)
            {
                
                var Info=HttpContext.GetClaimsData();

                ViewBag.I = Info.Id;
                ViewBag.N = Info.Name;
                ViewBag.E = Info.Email;
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
