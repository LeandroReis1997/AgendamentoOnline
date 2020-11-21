using SchedulingMeetings.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchedulingMeetings.Web.Repository.Service
{
    public interface IRoomService
    {
        List<RoomViewModel> GetAllRoom();
        RoomViewModel GetByRoomIdentity(Guid roomIdentity);
        RoomViewModel GetByRoom(string nameRoom);
        Task<RoomViewModel> AddRoom(RoomViewModel room);
        Task<RoomViewModel> EditRoom(Guid roomIdentity, RoomViewModel room);
        Guid DeleteRoom(Guid roomIdentity);
    }
}
