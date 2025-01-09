using CollegeProject.Models;
using CollegeProject.RepoClass;
using Microsoft.AspNetCore.Mvc;

namespace CollegeProject.Controllers
{
    public class AgnetDashboard : Controller
    {
        private readonly Iagentdashservices _agentdashservices;

        public AgnetDashboard(Iagentdashservices agentdashservices)
        {
            _agentdashservices = agentdashservices;
        }

        public IActionResult Index()
        {
            var a = HttpContext.GetClaimsData();
            ViewBag.ID = a.Id;
            ViewBag.Name = a.Name;
            return View();

        }
        
        public IActionResult AgentTask()
        {
            var claimdata = HttpContext.GetClaimsData();
            ViewBag.Id = claimdata.Id;
            return View();
           
            
        }

        
        public IActionResult AgentTaskJson(AgentTaskModel agent)
        {
            
            var a = _agentdashservices.GetAgentTask(agent);
            return Json(a);
        }

        public IActionResult DeliveryStatusAgent1(OrderStatus order)
        {
            var a = _agentdashservices.getOrderStatusByAgent1(order);
            return Json(a);
        }

        public IActionResult AgentPastRecords()
        {
            var claimdata = HttpContext.GetClaimsData();
            ViewBag.Id = claimdata.Id;
            return View();
        }

        public IActionResult AgentRecord(AgentTaskModel agent)
        {
            var a = _agentdashservices.GetAgentRecords(agent);
            return Json(a);

        }
    }
}
