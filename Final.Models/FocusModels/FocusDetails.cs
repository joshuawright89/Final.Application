using Final.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Final.Models.FocusModels
{
    public class FocusDetails
    {
        [Key]
        [Display(Name ="Focus number:")]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Focus purpose:")]
        public string FocusLabel { get; set; }
        
        [Display(Name ="Days with this Focus assigned:")]
        public ICollection<Day> DaysAssignedThisFocus { get; set; } = new List<Day>();
    }
}
