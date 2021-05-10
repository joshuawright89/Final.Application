using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Final.Data.Entities
{
    public class Day //cohort
    {
        [Required]
        public DateTime Today { get; set; }

        [Key]
        public int Id { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        public string DayLabel { get; set; }

        public virtual ICollection<ToDosForTheDay> ToDosAssignedForToday { get; set; } = new List<ToDosForTheDay>();
        
    }
}
