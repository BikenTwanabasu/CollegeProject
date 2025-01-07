using CollegeProject.Models;
using CollegeProject.RepoClass;
using Microsoft.AspNetCore.Mvc;

namespace CollegeProject.Controllers
{
    public class AgnetDashboard : Controller
    {
        private Iagentdashservices _agentdashservices;
        public IActionResult Index()
        {
            var a = HttpContext.GetClaimsData();
            ViewBag.ID = a.Id;
            ViewBag.Name = a.Name;
            return View();

        }
        public IActionResult AgentTask(AgentTaskModel agent)
        {
            return View();
        }

    }
}
