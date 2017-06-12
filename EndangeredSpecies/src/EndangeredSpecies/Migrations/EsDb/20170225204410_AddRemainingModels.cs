using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EndangeredSpecies.Migrations.EsDb
{
    public partial class AddRemainingModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Species");

            migrationBuilder.AddColumn<int>(
                name: "CountryCodeId",
                table: "Species",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusCodeId",
                table: "Species",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Cart",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SpeciesId",
                table: "Cart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cart",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCodeId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "StatusCodeId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "SpeciesId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Species",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Species",
                nullable: false,
                defaultValue: 0);
        }
    }
}
