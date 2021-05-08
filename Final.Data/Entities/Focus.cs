﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.Entities
{
    public class Focus
    {
        [Key]
        public int FocusId { get; set; }

        [Key]
        [Required]
        public string FocusName { get; set; }

        [ForeignKey(nameof(DaysAssignedThisFocus))]
        public ICollection<Day> DaysAssignedThisFocus { get; set; }
    }
}
