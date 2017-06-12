using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EndangeredSpecies.Migrations.EsDb
{
    public partial class AddCartFKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cart_SpeciesId",
                table: "Cart",
                column: "SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Species_SpeciesId",
                table: "Cart",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Species_SpeciesId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_SpeciesId",
                table: "Cart");
        }
    }
}
