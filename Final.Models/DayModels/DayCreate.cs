using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Models.DayModels
{
    public class DayCreate
    {
        [Required]
        [Display(Name = "Today's date:")]
        public DateTime Today { get; set; }

        [Display(Name = "Optional Note for today:")]
        public string DayLabel { get; set; }
    }
}
