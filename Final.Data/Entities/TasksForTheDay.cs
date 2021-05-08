using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.Entities
{
    public class TasksForTheDay
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Day))]
        public int DayId { get; set; }
        public virtual Day Day { get; set; }

        [ForeignKey(nameof(Task))]
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }


    }
}
