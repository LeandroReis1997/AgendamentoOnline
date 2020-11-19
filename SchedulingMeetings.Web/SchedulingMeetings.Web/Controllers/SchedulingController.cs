using Microsoft.AspNetCore.Mvc;

namespace SchedulingMeetings.Web.Controllers
{
    public class SchedulingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}