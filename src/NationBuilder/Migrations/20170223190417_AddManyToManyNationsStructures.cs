using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NationBuilder.Migrations
{
    public partial class AddManyToManyNationsStructures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Structures_Nations_NationId",
                table: "Structures");

            migrationBuilder.DropIndex(
                name: "IX_Structures_NationId",
                table: "Structures");

            migrationBuilder.DropColumn(
                name: "NationId",
                table: "Structures");

            migrationBuilder.CreateTable(
                name: "NationsStuctures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NationId = table.Column<int>(nullable: true),
                    StructureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationsStuctures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NationsStuctures_Nations_NationId",
                        column: x => x.NationId,
                        principalTable: "Nations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NationsStuctures_Structures_StructureId",
                        column: x => x.StructureId,
                        principalTable: "Structures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NationsStuctures_NationId",
                table: "NationsStuctures",
                column: "NationId");

            migrationBuilder.CreateIndex(
                name: "IX_NationsStuctures_StructureId",
                table: "NationsStuctures",
                column: "StructureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NationsStuctures");

            migrationBuilder.AddColumn<int>(
                name: "NationId",
                table: "Structures",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Structures_NationId",
                table: "Structures",
                column: "NationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Structures_Nations_NationId",
                table: "Structures",
                column: "NationId",
                principalTable: "Nations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
