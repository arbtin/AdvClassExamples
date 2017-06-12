using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EndangeredSpecies.Models
{
    public class StatusCode
    {
        //"Threatened" or "Endangered".
        [Key]
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }

        public virtual ICollection<Species> Species { get; set; }
    }
}
