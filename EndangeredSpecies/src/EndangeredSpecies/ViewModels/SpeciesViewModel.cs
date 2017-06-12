using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EndangeredSpecies.Models;
using System.Threading.Tasks;

namespace EndangeredSpecies.ViewModels
{
    public class SpeciesViewModel
    {
        private IQueryable<Species> species;

        //public SpeciesViewModel(IQueryable<Species> species)
        //{
        //    this.species = species;
        //}

        public SpeciesViewModel()
        {
        }

        public int Id { get; set; }
        [Display(Name = "Common Name")]
        public string ComName { get; set; }
        [Display(Name = "Scientific Name")]
        public string SciName { get; set; }
        [Display(Name = "Status")]
        public string StatusCodeLabel { get; set; }
        public int StatusCodeId { get; set; }
        [Display(Name = "Country")]
        public string CountryCodeLabel { get; set; }
        public int CountryCodeId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:D}", ApplyFormatInEditMode = false)]
        public DateTime ListingDate { get; set; }

        public virtual StatusCode StatusCode { get; set; }
        public virtual CountryCode CountryCode { get; set; }
    }
}