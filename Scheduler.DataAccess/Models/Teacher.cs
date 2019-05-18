using Scheduler.DataAccess.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduler.DataAccess.Models
{
    public partial class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
