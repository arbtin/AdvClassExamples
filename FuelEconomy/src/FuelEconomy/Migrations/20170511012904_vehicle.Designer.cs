using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FuelEconomy.Data;

namespace FuelEconomy.Migrations
{
    [DbContext(typeof(VehicleDbContext))]
    [Migration("20170511012904_vehicle")]
    partial class vehicle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FuelEconomy.Models.Cylinders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("Id");

                    b.ToTable("Cylinders");
                });

            modelBuilder.Entity("FuelEconomy.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CityMilage");

                    b.Property<int>("CylindersId");

                    b.Property<decimal>("Displacement");

                    b.Property<int>("DriveId");

                    b.Property<decimal>("FuelCost");

                    b.Property<int>("FuelTypeId");

                    b.Property<decimal>("HywayMilage");

                    b.Property<int>("MakeiId");

                    b.Property<string>("Model");

                    b.Property<int>("TransmissionId");

                    b.Property<int>("VehicleClassId");

                    b.Property<int>("YearId");

                    b.HasKey("Id");

                    b.HasIndex("CylindersId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("FuelEconomy.Models.Vehicle", b =>
                {
                    b.HasOne("FuelEconomy.Models.Cylinders", "Cylinders")
                        .WithMany("Vehicle")
                        .HasForeignKey("CylindersId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
