using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EndangeredSpecies.Models
{
    public class CountryCode
    {
        //1 Domestic
        //2	Foreign
        //3	Both domestic and Foreign
        [Key]
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }

        public virtual ICollection<Species> Species { get; set; }
    }
}
