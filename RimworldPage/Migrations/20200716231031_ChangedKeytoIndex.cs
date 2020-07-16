using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class ChangedKeytoIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Mod_Id",
                table: "Mod");

            migrationBuilder.CreateIndex(
                name: "IX_Mod_Id",
                table: "Mod",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Mod_Id",
                table: "Mod");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Mod_Id",
                table: "Mod",
                column: "Id");
        }
    }
}
