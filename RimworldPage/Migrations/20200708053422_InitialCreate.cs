﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mod",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SteamUrl = table.Column<string>(nullable: true),
                    ForumUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mod", x => new { x.Id, x.Name });
                    table.UniqueConstraint("AK_Mod_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModList",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Author = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_ModList", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "ModListMod",
                columns: table => new
                {
                    ModListId = table.Column<string>(nullable: false),
                    ModId = table.Column<string>(nullable: false),
                    ModName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModListMod", x => new { x.ModListId, x.ModId });
                    table.ForeignKey(
                        name: "FK_ModListMod_ModList_ModListId",
                        column: x => x.ModListId,
                        principalTable: "ModList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModListMod_Mod_ModId_ModName",
                        columns: x => new { x.ModId, x.ModName },
                        principalTable: "Mod",
                        principalColumns: new[] { "Id", "Name" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModListMod_ModId_ModName",
                table: "ModListMod",
                columns: new[] { "ModId", "ModName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModListMod");

            migrationBuilder.DropTable(
                name: "ModList");

            migrationBuilder.DropTable(
                name: "Mod");
        }
    }
}