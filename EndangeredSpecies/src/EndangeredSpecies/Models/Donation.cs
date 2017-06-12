using System.ComponentModel.DataAnnotations;

namespace EndangeredSpecies.Models
{
    public class Donation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Common Name")]
        public int SpeciesId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Donation")]
        public decimal Amount { get; set; }

        //public virtual ApplicationUser User { get; set; }
        public virtual Species Species { get; set; }
    }
}
