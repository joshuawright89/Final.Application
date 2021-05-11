using Final.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Models
{
    public class ToDoListItem
    {
        [Key]
        [Display(Name="Id:")]
        public int Id { get; set; }

        [Display(Name="To-do:")]
        public string ToDoName { get; set; }

        [Display(Name = "Days assigned this To-Do:")]
        [ForeignKey(nameof(DaysAssignedThisToDO))]
        public ICollection<ToDosForTheDay> DaysAssignedThisToDO { get; set; } = new List<ToDosForTheDay>();
    }
}
