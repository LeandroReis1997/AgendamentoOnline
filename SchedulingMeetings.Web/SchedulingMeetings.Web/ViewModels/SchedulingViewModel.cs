﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulingMeetings.Web.ViewModels
{
    public class SchedulingViewModel
    {
        public Guid SchedulingIdentity { get; set; }
        public string Title { get; set; }
        public Guid RoomIdentity { get; set; }
        public RoomViewModel Rooms { get; set; }
        public IEnumerable<RoomViewModel> Room { get; set; }
        public DateTime DateStartTime { get; set; }
        public DateTime DateEndTime { get; set; }
    }
}
