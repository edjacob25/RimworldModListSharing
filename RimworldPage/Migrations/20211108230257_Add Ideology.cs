using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication.Migrations
{
    public partial class AddIdeology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"ModList\" ALTER COLUMN \"Expansions\" TYPE VARCHAR(255);");

            migrationBuilder.Sql(@"DROP TYPE IF EXISTS expansions; 
                CREATE TYPE expansions AS ENUM ( 
                    'royalty', 
                    'ideology');");

            migrationBuilder.Sql("ALTER TABLE \"ModList\" ALTER COLUMN \"Expansions\" TYPE expansions[] USING (\"Expansions\"::expansions[]);");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ModList",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"ModList\" ALTER COLUMN \"Expansions\" TYPE VARCHAR(255);");

            migrationBuilder.Sql(@"DROP TYPE IF EXISTS expansions; 
                CREATE TYPE expansions AS ENUM ( 
                    'royalty');");

            migrationBuilder.Sql("ALTER TABLE \"ModList\" ALTER COLUMN \"Expansions\" TYPE expansions[] USING (\"Expansions\"::expansions[]);");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ModList",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
