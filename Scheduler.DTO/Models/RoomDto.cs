using Scheduler.DataAccess.Models;
using Scheduler.DataAccess.Models.Enums;
using System.Collections.Generic;

namespace Scheduler.DTO.Models
{
    public partial class RoomDto
    {
        public int RoomId { get; set; }
        public int RoomNumberd { get; set; }
        public string Adress { get; set; }
        public int Capacity { get; set; }
        public Type Type { get; set; }

        public ICollection<Schedule> Schedule { get; set; }
    }
}
