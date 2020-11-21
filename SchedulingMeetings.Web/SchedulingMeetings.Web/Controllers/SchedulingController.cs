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

        public async Task<IActionResult> Index(Guid id)
        {
            var schedulingService = new SchedulingService();
            var scheduling = _mapper.Map<IEnumerable<SchedulingViewModel>>(await schedulingService.GetBySchedulingRoomIdentity(id));

            return View(scheduling);
        }

        public async Task<IActionResult> GetAllRoomsScheduling()
        {
            var roomService = new RoomService();
            var room = _mapper.Map<IEnumerable<RoomViewModel>>(await roomService.GetAllRoom());

            return View("Room", room);
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
            try
            {
                var schedulingService = new SchedulingService();
                _mapper.Map<SchedulingViewModel>(await schedulingService.AddRoomScheduling(scheduling));
                return RedirectToAction("GetAllRoomsScheduling");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ScheduledRoom");
            }
        }

        [HttpGet]
        [Route("updatescheduling/{id}")]
        public async Task<IActionResult> EditScheduling(Guid id)
        {
            var roomService = new RoomService();
            var schedulingService = new SchedulingService();
            var scheduling = _mapper.Map<SchedulingViewModel>(await schedulingService.GetByschedulingIdentity(id));
            scheduling.Room = _mapper.Map<IEnumerable<RoomViewModel>>(await roomService.GetAllRoom());
            return View("Edit", scheduling);
        }

        [HttpPost]
        [Route("updatescheduling/{id}")]
        public async Task<IActionResult> EditScheduling(Guid id, SchedulingViewModel scheduling)
        {
            var schedulingService = new SchedulingService();
            var update = _mapper.Map<SchedulingViewModel>(await schedulingService.EditRoomScheduling(id, scheduling));
            return RedirectToAction("ScheduledRoom", update);
        }
               
        [Route("deletescheduling/{id}")]
        public async Task<IActionResult> DeleteScheduling(Guid id)
        {
            var schedulingService = new SchedulingService();
            _mapper.Map<SchedulingViewModel>(await schedulingService.DeleteRoomScheduling(id));
            return RedirectToAction("Index");
        }

        public  IActionResult ScheduledRoom()
        {
            return View();
        }


    }
}