using SchedulingMeetings.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchedulingMeetings.Web.Repository.Service
{
    public interface IRoomService
    {
        List<Room> GetAllRoom();
        Room GetByRoomIdentity(Guid roomIdentity);
        Room GetByRoom(string nameRoom);
        Task<Room> AddRoom(Room room);
        Task<Room> EditRoom(Guid roomIdentity, Room room);
        Guid DeleteRoom(Guid roomIdentity);
    }
}
