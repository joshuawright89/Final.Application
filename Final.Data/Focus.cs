using Final.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data
{
    public class Focus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FocusLabel { get; set; }

        public virtual ICollection<Day> DaysAssignedThisFocus { get; set; } = new List<Day>();
    }
}
