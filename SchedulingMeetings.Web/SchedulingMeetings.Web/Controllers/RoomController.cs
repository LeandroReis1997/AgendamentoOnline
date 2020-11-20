using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchedulingMeetings.Web.DTO.Room;
using SchedulingMeetings.Web.Models;
using SchedulingMeetings.Web.Repository.Service;
using SchedulingMeetings.Web.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
            var room = await roomService.GetAllRoom
            ().Result.Content.ReadAsAsync<List<Room>>();
            return View(room);
        }

        [Route("addroom")]
        public IActionResult AddRoom()
        {
            return View("create", new Room());
        }

        [HttpPost]
        [Route("createroom")]
        public async Task<IActionResult> CreateRoom(Room room)
        {
            var roomService = new RoomService();
            var createRoom = await roomService.AddRoom(room);
            return RedirectToAction("Index", createRoom);
        }
        
        [HttpGet]
        [Route("updateroom/{id}")]
        public IActionResult EditRoom(Guid id)
        {
            var roomService = new RoomService();
            var room = roomService.GetByRoomIdentity
                (id).Result.Content.ReadAsAsync<Room>().Result;
            return View("Edit", room);
        }

        [HttpPost]
        [Route("updateroom/{id}")]
        public async Task<IActionResult> EditRoom(Guid id, Room room)
        {
            var roomService = new RoomService();
            var update = await roomService.EditRoom(id, room);
            return RedirectToAction("Index", update);
        }

        [Route("deleteroom/{id}")]
        public async Task<IActionResult> DeleteRoom(Guid id)
        {
            var roomService = new RoomService();
            await roomService.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
}