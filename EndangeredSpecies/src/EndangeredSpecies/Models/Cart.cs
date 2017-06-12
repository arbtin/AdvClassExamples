using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EndangeredSpecies.Models
{
    public class CartList
    {
        private List<Cart> cartCollection = new List<Cart>();

        public virtual void AddItem(Species species)
        {
            Cart cart = cartCollection.Where(s => s.Species.Id == species.Id).FirstOrDefault();

            if (cart == null)
            {
                cartCollection.Add(new Cart
                {
                    Species = species
                });
            }
        }

        public virtual void RemoveItem(Species species) => cartCollection.RemoveAll(l => l.Species.Id == species.Id);

        public virtual decimal ComputeTotalValue() => cartCollection.Sum(e => e.Amount);

        public virtual void Clear() => cartCollection.Clear();

        public virtual IEnumerable<Cart> Carts => cartCollection;
    }

    public class Cart
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
