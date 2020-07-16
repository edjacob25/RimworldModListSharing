using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication.Models.Database;

namespace WebApplication.Migrations
{
    public partial class AddedVersionAndExpansions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:expansions", "royalty");

            migrationBuilder.AddColumn<List<Expansions>>(
                name: "Expansions",
                table: "ModList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "ModList",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expansions",
                table: "ModList");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "ModList");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:expansions", "royalty");
        }
    }
}
