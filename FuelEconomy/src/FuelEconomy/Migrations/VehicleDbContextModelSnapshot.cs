using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FuelEconomy.Data;

namespace FuelEconomy.Migrations
{
    [DbContext(typeof(VehicleDbContext))]
    partial class VehicleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("FuelEconomy.Models.Drive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("Id");

                    b.ToTable("Drive");
                });

            modelBuilder.Entity("FuelEconomy.Models.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("Id");

                    b.ToTable("FuelType");
                });

            modelBuilder.Entity("FuelEconomy.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("Id");

                    b.ToTable("Make");
                });

            modelBuilder.Entity("FuelEconomy.Models.Transmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("Id");

                    b.ToTable("Transmission");
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

                    b.Property<int>("MakeId");

                    b.Property<string>("Model");

                    b.Property<int>("TransmissionId");

                    b.Property<int>("VehicleClassId");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("CylindersId");

                    b.HasIndex("DriveId");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("MakeId");

                    b.HasIndex("TransmissionId");

                    b.HasIndex("VehicleClassId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("FuelEconomy.Models.VehicleClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("Id");

                    b.ToTable("VehicleClass");
                });

            modelBuilder.Entity("FuelEconomy.Models.Vehicle", b =>
                {
                    b.HasOne("FuelEconomy.Models.Cylinders", "Cylinders")
                        .WithMany("Vehicle")
                        .HasForeignKey("CylindersId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FuelEconomy.Models.Drive", "Drive")
                        .WithMany("Vehicle")
                        .HasForeignKey("DriveId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FuelEconomy.Models.FuelType", "FuelType")
                        .WithMany("Vehicle")
                        .HasForeignKey("FuelTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FuelEconomy.Models.Make", "Make")
                        .WithMany("Vehicle")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FuelEconomy.Models.Transmission", "Transmission")
                        .WithMany("Vehicle")
                        .HasForeignKey("TransmissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FuelEconomy.Models.VehicleClass", "VehicleClass")
                        .WithMany("Vehicle")
                        .HasForeignKey("VehicleClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
