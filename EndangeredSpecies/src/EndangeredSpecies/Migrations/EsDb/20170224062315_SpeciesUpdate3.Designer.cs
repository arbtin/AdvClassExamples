using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EndangeredSpecies.Data;

namespace EndangeredSpecies.Migrations.EsDb
{
    [DbContext(typeof(EsDbContext))]
    [Migration("20170224062315_SpeciesUpdate3")]
    partial class SpeciesUpdate3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EndangeredSpecies.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("EndangeredSpecies.Models.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComName");

                    b.Property<int>("CountryId");

                    b.Property<int>("EntityId");

                    b.Property<DateTime>("ListingDate");

                    b.Property<string>("PopAbbrev");

                    b.Property<string>("PopDesc");

                    b.Property<string>("SciName");

                    b.Property<string>("SpCode");

                    b.Property<int>("StatusId");

                    b.Property<int>("TSN");

                    b.Property<string>("VipCode");

                    b.HasKey("Id");

                    b.ToTable("Species");
                });
        }
    }
}
