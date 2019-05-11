using System;
using System.Collections.Generic;

namespace Scheduler.DataAccess.Models
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public int RoomId { get; set; }
        public int GroupId { get; set; }
        public int? TeacherId { get; set; }
        public string Day { get; set; }
        public short? Lesson { get; set; }

        public virtual Group Group { get; set; }
        public virtual Room Room { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
