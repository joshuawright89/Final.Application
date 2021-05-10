using Final.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Models
{
    public class DayDetails
    {
        [Display(Name="Day Number:")]
        public int Id { get; set; }

        [Display(Name = "Date:")]
        public DateTime Today { get; set; }

        public Guid OwnerId { get; set; }

        [Display(Name = "Optional Label:")]
        public string DayLabel { get; set; }

        [Display(Name = "ToDos for this day:")]
        public virtual ICollection<ToDosForTheDay> ToDosAssignedForToday { get; set; } = new List<ToDosForTheDay>();
    }
}
