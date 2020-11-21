using SchedulingMeetings.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingMeetings.Web.DTO.Scheduling
{
    public class SchedulingListDTO
    {
        public Guid SchedulingIdentity { get; set; }
        public string Title { get; set; }
        public Guid RoomIdentity { get; set; }
        public RoomViewModel Rooms { get; set; }
        //public IEnumerable<RoomViewModel> Room { get; set; }
        public DateTime DateStartTime { get; set; }
        public DateTime DateEndTime { get; set; }
    }
}
