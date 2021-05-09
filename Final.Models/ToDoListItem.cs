using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Models
{
    public class ToDoListItem
    {
        [Display(Name="Id:")]
        public int ToDoId { get; set; }

        [Display(Name="To-do:")]
        public string ToDoName { get; set; }

    }
}
