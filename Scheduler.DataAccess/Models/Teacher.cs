using System;
using System.Collections.Generic;

namespace Scheduler.DataAccess.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Schedule = new HashSet<Schedule>();
        }

        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
