using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Models.TaskModels
{
    public class ToDoCreate
    {
        [Required]
        [Display(Name = "To-do:")]
        public string TaskName { get; set; }
    }
}
