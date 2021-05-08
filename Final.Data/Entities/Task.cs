using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.Entities
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string TaskName { get; set; }

        public virtual ICollection<TasksForTheDay> Tasks { get; set; } = new List<TasksForTheDay>();
    }
}
