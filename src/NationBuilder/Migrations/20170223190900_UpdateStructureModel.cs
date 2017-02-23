using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NationBuilder.Migrations
{
    public partial class UpdateStructureModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovalCost",
                table: "Structures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EconomyCost",
                table: "Structures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PopulationCost",
                table: "Structures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResourcesCost",
                table: "Structures",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalCost",
                table: "Structures");

            migrationBuilder.DropColumn(
                name: "EconomyCost",
                table: "Structures");

            migrationBuilder.DropColumn(
                name: "PopulationCost",
                table: "Structures");

            migrationBuilder.DropColumn(
                name: "ResourcesCost",
                table: "Structures");
        }
    }
}
