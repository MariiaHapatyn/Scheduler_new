using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduler.DataAccess.Models
{
    public partial class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }
        public int RoomNumberd { get; set; }
        public string Adress { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
