using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuelEconomy.Models;
using System.ComponentModel.DataAnnotations;

namespace FuelEconomy.ViewModels
{
    public class VehicleViewModel
    {
        private IQueryable<Vehicle> vehicle;

        public VehicleViewModel()
        {
        }

        public int Id { get; set; }

        [Display(Name = "Cylinders")]
        public string CylindersLabel { get; set; }
        public int CylindersId { get; set; }

        public decimal Displacement { get; set; }

        [Display(Name = "Drive")]
        public string DriveLabel { get; set; }
        public int DriveId { get; set; }

        public decimal FuelCost { get; set; }

        [Display(Name = "Fuel Type")]
        public string FuelTypeLabel { get; set; }
        public int FuelTypeId { get; set; }

        [Display(Name = "Make")]
        public string MakeLabel { get; set; }
        public int MakeId { get; set; }

        public string Model { get; set; }

        [Display(Name = "Transmission")]
        public string TransmissionLabel { get; set; }
        public int TransmissionId { get; set; }

        public decimal CityMilage { get; set; }

        public decimal HywayMilage { get; set; }

        [Display(Name = "Vehicle Class")]
        public string VehicleClassLabel { get; set; }
        public int VehicleClassId { get; set; }

        public int Year { get; set; }

        public virtual Cylinders Cylinders { get; set; }
        public virtual Drive Drive { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual Make Make { get; set; }
        public virtual Transmission Transmission { get; set; }
        public virtual VehicleClass VehicleClass { get; set; }
    }
}