using System.ComponentModel.DataAnnotations;

namespace Lager_App.Model
{
    public class BookOutForm
    {
        [Required]
        public int ArticelNumber { get; set; } = 0;

        [Required]
        [Range(0, 1000000, ErrorMessage = "Range is not valid")]
        public int DesiredCount { get; set; } = 0;
    }
}
