using Microsoft.AspNetCore.Mvc;

namespace SchedulingMeetings.Web.Controllers
{
    public class UserAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        public IActionResult Edit()
        {
            return View();
        }
    }
}