using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulingMeetings.Web.Models
{
    public class Scheduling
    {
        public Guid SchedulingIdentity { get; set; }
        public string Title { get; set; }
        public Guid RoomIdentity { get; set; }
        [ForeignKey("RoomIdentity")]
        public virtual Room Rooms { get; set; }
        public DateTime DateStartTime { get; set; }
        public DateTime DateEndTime { get; set; }
    }
}
