using System.ComponentModel.DataAnnotations;

namespace Lager_App.Model
{
    public class ChangeArticelForm
    {

        [Required]
        [StringLength(100, ErrorMessage = "Name is not valid", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(0, 1000000, ErrorMessage = "Range is not valid")]
        public float Price { get; set; }


        public ChangeArticelForm(Articel articel)
        {
            Name = articel.Name;
            Price = articel.Price;
        }
    }
}
