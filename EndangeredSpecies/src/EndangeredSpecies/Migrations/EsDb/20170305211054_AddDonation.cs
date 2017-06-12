using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EndangeredSpecies.Migrations.EsDb
{
    public partial class AddDonation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Donation_SpeciesId",
                table: "Donation",
                column: "SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_Species_SpeciesId",
                table: "Donation",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donation_Species_SpeciesId",
                table: "Donation");

            migrationBuilder.DropIndex(
                name: "IX_Donation_SpeciesId",
                table: "Donation");
        }
    }
}
