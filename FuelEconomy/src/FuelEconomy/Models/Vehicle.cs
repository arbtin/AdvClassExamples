using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelEconomy.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int CylindersId { get; set; }
        public decimal Displacement { get; set; }
        public int DriveId { get; set; }
        public decimal FuelCost { get; set; }
        public int FuelTypeId { get; set; }
        public int MakeId { get; set; }
        public string Model { get; set; }
        public int TransmissionId { get; set; }
        public decimal CityMilage { get; set; }
        public decimal HywayMilage { get; set; }
        public int VehicleClassId { get; set; }
        public int Year { get; set; }

        public virtual Cylinders Cylinders { get; set; }
        public virtual Drive Drive { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual Make Make { get; set; }
        public virtual Transmission Transmission { get; set; }
        public virtual VehicleClass VehicleClass { get; set; }
    }

    public class Cylinders
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }

    public class Drive
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }

    public class FuelType
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }

    public class Make
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }

    public class Transmission
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }

    public class VehicleClass
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
