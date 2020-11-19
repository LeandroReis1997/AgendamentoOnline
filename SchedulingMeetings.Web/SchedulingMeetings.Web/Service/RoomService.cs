using SchedulingMeetings.Web.Models;
using SchedulingMeetings.Web.Repository.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchedulingMeetings.Web.Service
{
    public class RoomRoomService : IRoomService
    {
        public Task<Room> AddRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public Guid DeleteRoom(Guid roomIdentity)
        {
            throw new NotImplementedException();
        }

        public Task<Room> EditRoom(Guid roomIdentity, Room room)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllRoom()
        {
            throw new NotImplementedException();
        }

        public Room GetByRoom(string nameRoom)
        {
            throw new NotImplementedException();
        }

        public Room GetByRoomIdentity(Guid roomIdentity)
        {
            throw new NotImplementedException();
        }
    }
}
