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
        public DateTime Today { get; set; }
    }
}
