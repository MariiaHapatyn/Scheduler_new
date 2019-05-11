using Scheduler.DataAccess.Models;

namespace Scheduler.DTO.Models
{
    public partial class SchedulerDto
    {
        public int ScheduleId { get; set; }
        public int RoomId { get; set; }
        public int GroupId { get; set; }
        public int? TeacherId { get; set; }
        public string Day { get; set; }
        public short? Lesson { get; set; }

        public Group Group { get; set; }
        public Room Room { get; set; }
        public Teacher Teacher { get; set; }
    }
}
