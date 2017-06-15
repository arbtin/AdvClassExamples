using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EndangeredSpecies.Models;
using System.Threading.Tasks;

namespace EndangeredSpecies.ViewModels
{
    public class PartialSpeciesViewModel
    {
        private IQueryable<Species> species;

        //public SpeciesViewModel(IQueryable<Species> species)
        //{
        //    this.species = species;
        //}

        public PartialSpeciesViewModel()
        {
        }

        public int Id { get; set; }


        public string SpCode { get; set; }
        public string VipCode { get; set; }
        public string PopAbbrev { get; set; }
        public string PopDesc { get; set; }
        public int TSN { get; set; }

    }
}