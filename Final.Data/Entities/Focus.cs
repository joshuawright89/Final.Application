using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.Entities
{
    public class Focus
    {
        [Key]
        public int FocusId { get; set; }

        [Required]
        [Key]
        public string Purpose { get; set; }

        public ICollection<Day> Days { get; set; }
    }
}
