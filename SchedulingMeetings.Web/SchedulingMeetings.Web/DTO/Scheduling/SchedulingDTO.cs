using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingMeetings.Web.DTO.Scheduling
{
    public class SchedulingDTO
    {
        public string Title { get; set; }
        public Guid Room { get; set; }

        public DateTime DateStartTime { get; set; }

        public DateTime DateEndTime { get; set; }
    }
}
