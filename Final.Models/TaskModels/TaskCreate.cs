using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Models.TaskModels
{
    public class TaskCreate
    {
        [Required]
        [Display(Name = "Task:")]
        public string TaskName { get; set; }
    }
}
