using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FuelEconomy.Models;

namespace FuelEconomy.Data
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext() { }

        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Cylinders> Cylinders { get; set; }
        public DbSet<Drive> Drive { get; set; }
        public DbSet<FuelType> FuelType  { get; set; }
        public DbSet<Make> Make { get; set; }
        public DbSet<Transmission> Transmission { get; set; }
        public DbSet<VehicleClass> VehicleClass { get; set; }
    }
}