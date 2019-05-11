using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Scheduler.DataAccess.Models
{
    public partial class User: IdentityUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistredOn { get; set; }
    }
}
