using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EndangeredSpecies.Migrations.EsDb
{
    public partial class AddVirtuals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Species_CountryCodeId",
                table: "Species",
                column: "CountryCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_StatusCodeId",
                table: "Species",
                column: "StatusCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Species_CountryCode_CountryCodeId",
                table: "Species",
                column: "CountryCodeId",
                principalTable: "CountryCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Species_StatusCode_StatusCodeId",
                table: "Species",
                column: "StatusCodeId",
                principalTable: "StatusCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Species_CountryCode_CountryCodeId",
                table: "Species");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_StatusCode_StatusCodeId",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Species_CountryCodeId",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Species_StatusCodeId",
                table: "Species");
        }
    }
}
