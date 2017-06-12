using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EndangeredSpecies.Data;

namespace EndangeredSpecies.Migrations.EsDb
{
    [DbContext(typeof(EsDbContext))]
    [Migration("20170223050209_SpeciesUpdate1")]
    partial class SpeciesUpdate1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EndangeredSpecies.Models.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComName");

                    b.Property<string>("Name");

                    b.Property<string>("SciName")
                        .IsRequired();

                    b.Property<string>("title");

                    b.HasKey("Id");

                    b.ToTable("Species");
                });
        }
    }
}
