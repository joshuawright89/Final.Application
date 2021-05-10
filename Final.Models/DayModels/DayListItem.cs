using Final.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Models.DayModels
{
    public class DayListItem
    {
        [Required]
        [Display(Name = "Date:")]
        public DateTime Today { get; set; }

        [Key]
        [Display(Name = "Day Number:")]
        public int Id { get; set; }

        public Guid OwnerId { get; set; }

        [Display(Name = "Optional label for this day:")]
        public string DayLabel { get; set; }

        [Display(Name = "ToDos assigned to this day:")]
        [ForeignKey(nameof(ToDosAssignedForToday))]
        public virtual ICollection<ToDosForTheDay> ToDosAssignedForToday { get; set; } = new List<ToDosForTheDay>();
    }
}
