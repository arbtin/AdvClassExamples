using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EndangeredSpecies.Migrations.EsDb
{
    public partial class SpeciesUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "title",
                table: "Species");

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Species",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "Species",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ListingDate",
                table: "Species",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PopAbbrev",
                table: "Species",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PopDesc",
                table: "Species",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpCode",
                table: "Species",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Species",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TSN",
                table: "Species",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VipCode",
                table: "Species",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SciName",
                table: "Species",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "ListingDate",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "PopAbbrev",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "PopDesc",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "SpCode",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "TSN",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "VipCode",
                table: "Species");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Species",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Species",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SciName",
                table: "Species",
                nullable: false);
        }
    }
}
