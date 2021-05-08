using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Final.Data.Entities
{
    public class Day
    {
        [Required]
        public DateTime Today { get; set; }

        [Key]
        public int DayId { get; set; }
        
        public ICollection<Task> Tasks { get; set; }
        
        [ForeignKey]
        public int FocusId { get; set; }

    }
}
