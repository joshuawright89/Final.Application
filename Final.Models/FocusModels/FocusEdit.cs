using Final.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Final.Models.FocusModels
{
    public class FocusEdit
    {
        public int Id { get; set; }

        [Required]
        public string FocusLabel { get; set; }

        public ICollection<Day> DaysAssignedThisFocus { get; set; } = new List<Day>();
    }

}
