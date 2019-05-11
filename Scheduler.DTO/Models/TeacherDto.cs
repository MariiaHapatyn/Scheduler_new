using Scheduler.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.DTO.Models
{
    public partial class TeacherDto
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public ICollection<Schedule> Schedule { get; set; }
    }
}
