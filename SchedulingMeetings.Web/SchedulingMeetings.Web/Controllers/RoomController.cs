using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchedulingMeetings.Web.Service;
using SchedulingMeetings.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchedulingMeetings.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IMapper _mapper;

        public RoomController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var roomService = new RoomService();
            var rooms = _mapper.Map<IEnumerable<RoomViewModel>>(await roomService.GetAllRoom());

            return View(rooms);
        }

        [Route("addroom")]
        public IActionResult AddRoom()
        {
            return View("create", new RoomViewModel());
        }

        [HttpPost]
        [Route("createroom")]
        public async Task<IActionResult> CreateRoom(RoomViewModel room)
        {
            var roomService = new RoomService();
            var createRoom = _mapper.Map<RoomViewModel>(await roomService.AddRoom(room));
            return RedirectToAction("Index", createRoom);
        }

        [HttpGet]
        [Route("updateroom/{id}")]
        public async Task<IActionResult> EditRoom(Guid id)
        {
            var roomService = new RoomService();
            var room = _mapper.Map<RoomViewModel>(await roomService.GetByRoomIdentity(id));
            return View("Edit", room);
        }

        [HttpPost]
        [Route("updateroom/{id}")]
        public async Task<IActionResult> EditRoom(Guid id, RoomViewModel room)
        {
            var roomService = new RoomService();
            var update = _mapper.Map<RoomViewModel>(await roomService.EditRoom(id, room));
            return RedirectToAction("Index", update);
        }

        [Route("deleteroom/{id}")]
        public async Task<IActionResult> DeleteRoom(Guid id)
        {
            var roomService = new RoomService();
            _mapper.Map<RoomViewModel>(await roomService.DeleteRoom(id));
            return RedirectToAction("Index");
        }
    }
}