using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EndangeredSpecies.Models
{
    public interface ISpeciesRepository
    {
        IEnumerable<Species> Species { get; }
    }

    public class Species
    {
        [Key]
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string SciName { get; set; }
        public string ComName { get; set; }
        public int StatusCodeId { get; set; }
        public string SpCode { get; set; }
        public string VipCode { get; set; }
        public string PopAbbrev { get; set; }
        public string PopDesc { get; set; }
        public int TSN { get; set; }
        public int CountryCodeId { get; set; }
        public DateTime ListingDate { get; set; }

        public virtual StatusCode StatusCode { get; set; }
        public virtual CountryCode CountryCode { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
    }
}
