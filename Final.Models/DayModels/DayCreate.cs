using Final.Data;
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
    public class DayCreate  //This model "will allow us to have some validation for the [day] properties." (EN 5.02)
    {
        [Required]
        [Display(Name = "Today's date:")]
        public DateTime Today { get; set; }

        [Display(Name = "Optional Note for today:")]
        [MaxLength(100, ErrorMessage = "Calm down, bro!  100 characters or fewer, please.")]
        public string DayLabel { get; set; }

        [ForeignKey(nameof(Focus))]
        public int ? FocusId { get; set; }
        public Focus Focus { get; set; }

        public ICollection<ToDosForTheDay> ToDosAssignedForToday { get; set; }
    }
}
