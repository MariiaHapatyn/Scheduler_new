using Scheduler.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Scheduler.DTO.Models
{
    public class GroupDto
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string NumberOfStudents { get; set; }
        public ICollection<Schedule> Schedule { get; set; }
    }
}
