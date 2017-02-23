using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using NationBuilder.Models;

namespace NationBuilder.Migrations
{
    public partial class SeedDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (NationBuilderDbContext db = new NationBuilderDbContext())
            {
                db.Governments.AddRange(SeedData.SeedGovernments);
                db.Structures.AddRange(SeedData.SeedStructures);
                db.Events.AddRange(SeedData.SeedEvents);
                db.SaveChanges();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            using (NationBuilderDbContext db = new NationBuilderDbContext())
            {
                db.Governments.RemoveRange(db.Governments);
                db.Structures.RemoveRange(db.Structures);
                db.Events.RemoveRange(db.Events);
                db.SaveChanges();
            }
        }
    }
}
