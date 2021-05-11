using Final.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Models.ToDoModels
{
    public class ToDoEdit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "To-do:")]
        public string ToDoName { get; set; }


        public virtual ICollection<ToDosForTheDay> DaysAssignedThisToDo { get; set; } = new List<ToDosForTheDay>();

    }
}
