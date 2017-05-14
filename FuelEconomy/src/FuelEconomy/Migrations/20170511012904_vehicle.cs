using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FuelEconomy.Migrations
{
    public partial class vehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cylinders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cylinders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityMilage = table.Column<decimal>(nullable: false),
                    CylindersId = table.Column<int>(nullable: false),
                    Displacement = table.Column<decimal>(nullable: false),
                    DriveId = table.Column<int>(nullable: false),
                    FuelCost = table.Column<decimal>(nullable: false),
                    FuelTypeId = table.Column<int>(nullable: false),
                    HywayMilage = table.Column<decimal>(nullable: false),
                    MakeiId = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    TransmissionId = table.Column<int>(nullable: false),
                    VehicleClassId = table.Column<int>(nullable: false),
                    YearId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Cylinders_CylindersId",
                        column: x => x.CylindersId,
                        principalTable: "Cylinders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CylindersId",
                table: "Vehicle",
                column: "CylindersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Cylinders");
        }
    }
}
