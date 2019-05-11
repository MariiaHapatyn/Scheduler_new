using System;
using System.Collections.Generic;

namespace Scheduler.DataAccess.Models
{
    public partial class Room
    {
        public Room()
        {
            Schedule = new List<Schedule>();
        }

        public int RoomId { get; set; }
        public int RoomNumberd { get; set; }
        public string Adress { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
