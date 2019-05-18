using Scheduler.DataAccess.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduler.DataAccess.Models
{
    public partial class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleId { get; set; }
        public int RoomId { get; set; }
        public int GroupId { get; set; }
        public int? TeacherId { get; set; }
        public Day Day { get; set; }
        public Lesson Lesson { get; set; }

        public virtual Group Group { get; set; }
        public virtual Room Room { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
