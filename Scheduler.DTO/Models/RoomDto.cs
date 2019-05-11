using Scheduler.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.DTO.Models
{
    public partial class RoomDto
    {
        public int RoomId { get; set; }
        public int RoomNumberd { get; set; }
        public string Adress { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }

        public ICollection<Schedule> Schedule { get; set; }
    }
}
