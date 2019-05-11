using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Scheduler.DataAccess.Models
{
    public class Group
    {
        public Group()
        {
            Schedule = new List<Schedule>();
        }

        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string NumberOfStudents { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
