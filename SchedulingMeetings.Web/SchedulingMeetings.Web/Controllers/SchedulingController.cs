using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchedulingMeetings.Web.Service;
using SchedulingMeetings.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchedulingMeetings.Web.Controllers
{
    public class SchedulingController : Controller
    {
        private readonly IMapper _mapper;

        public SchedulingController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("addscheduling")]
        public async Task<IActionResult> AddScheduling()
        {
            var roomService = new RoomService();
            var scheduling = new SchedulingViewModel();
            scheduling.DateStartTime = DateTime.Today.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
            scheduling.DateEndTime = DateTime.Today.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
            scheduling.Room = _mapper.Map<IEnumerable<RoomViewModel>>(await roomService.GetAllRoom());
            return View("Create", scheduling);
        }

        [HttpPost]
        [Route("createscheduling")]
        public async Task<IActionResult> CreateScheduling(SchedulingViewModel scheduling)
        {
            var schedulingService = new SchedulingService();
            var createSscheduling = _mapper.Map<SchedulingViewModel>(await schedulingService.AddRoomScheduling(scheduling));
            return RedirectToAction("Index", createSscheduling);
        }

    }
}