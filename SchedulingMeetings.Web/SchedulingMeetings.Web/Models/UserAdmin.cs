using System;

namespace SchedulingMeetings.Web.Models
{
    public class UserAdmin
    {
        public Guid UserIdentity { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
