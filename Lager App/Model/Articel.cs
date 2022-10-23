using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Lager_App.Model
{
    public class Articel
    {
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public DateTime Updated { get; set; } = DateTime.Now;

        [Key]
        public int ArticelNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name is not valid", MinimumLength =3)]
        public string Name { get; set; } = String.Empty;

        [Required]
        [Range(0,1000000, ErrorMessage = "Range is not valid")]
        public int  Count { get; set; }

        [Range(0, 1000000, ErrorMessage = "Price is not valid")]
        public float Price { get; set; }


        

    }
}
