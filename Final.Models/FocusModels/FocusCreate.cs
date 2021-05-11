using System.ComponentModel.DataAnnotations;

namespace Final.Models.FocusModels
{
    public class FocusCreate
    {
        [Required]
        public string FocusLabel { get; set; }
    }
}
