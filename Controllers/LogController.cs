using CollegeProject.Models;
using CollegeProject.RepoClass;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace CollegeProject.Controllers
{
    public class LogController : Controller
    {
        private IServices _services;

        public LogController(IServices services)
        {
            _services = services;
        }
        
        public IActionResult AgentLoggingIn(Agent agent)
        {
            var a = _services.AgentLogIn(agent);
            if (a.ResponseCode!=null)
            {
                return Json(a);
            }
            return View();
        } 
        
        public IActionResult VendorLoggingIn(Vendor vendor)
        {
            var a = _services.VendorLogIn(vendor);
            if (a.ResponseCode!=null)
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

