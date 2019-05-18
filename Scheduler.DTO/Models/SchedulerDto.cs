using Scheduler.DataAccess.Models;
using Scheduler.DataAccess.Models.Enums;

namespace Scheduler.DTO.Models
{
    public partial class SchedulerDto
    {
        public int ScheduleId { get; set; }
        public int RoomId { get; set; }
        public int GroupId { get; set; }
        public int? TeacherId { get; set; }
        public Day Day { get; set; }
        public Lesson Lesson { get; set; }

        public Group Group { get; set; }
        public Room Room { get; set; }
        public Teacher Teacher { get; set; }
    }
}
