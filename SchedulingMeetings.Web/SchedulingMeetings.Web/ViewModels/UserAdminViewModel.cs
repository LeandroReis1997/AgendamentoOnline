using System;

namespace SchedulingMeetings.Web.ViewModels
{
    public class UserAdminViewModel
    {
        public Guid UserIdentity { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
