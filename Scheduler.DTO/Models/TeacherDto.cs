using Scheduler.DataAccess.Models;
using Scheduler.DataAccess.Models.Enums;
using System.Collections.Generic;

namespace Scheduler.DTO.Models
{
    public partial class TeacherDto
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }

        public ICollection<Schedule> Schedule { get; set; }
    }
}
