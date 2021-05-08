using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.Entities
{
    public class FocusAssignment
    {
        [Key]
        public int FocusId { get; set; }

        [Key, Column(Order = 0)]
        public string Purpose { get; set; }

        [ForeignKey(nameof(Day))]
        public virtual ICollection<Day> Days { get; set; }
    }
}
