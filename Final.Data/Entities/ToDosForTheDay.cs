using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.Entities
{
    public class ToDosForTheDay  //enrollment
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey(nameof(ToDo))]
        public int ToDoId { get; set; }
        public virtual ToDo ToDo { get; set; }

        [ForeignKey(nameof(Day))]
        public int DayId { get; set; }
        public virtual Day Day { get; set; }



    }
}
