using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.Entities
{
    public class ToDo  //student 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ToDoName { get; set; }

        public virtual ICollection<ToDosForTheDay> DaysAssignedThisToDo { get; set; } = new List<ToDosForTheDay>();  //this will take the ToDo object's Id and cross reference it with the TaskForTheDay class in the data layer, and populate this list with the matching results.  If none are found, it will automatically initialized a new list, as opposed to just leaving a broken end in the code.

    }
}
