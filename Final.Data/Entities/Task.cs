﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey(nameof(DaysAssignedThisTask))]
        public virtual ICollection<TasksForTheDay> DaysAssignedThisTask { get; set; } = new List<TasksForTheDay>();

    }
}
