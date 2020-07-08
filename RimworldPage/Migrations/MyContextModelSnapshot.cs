﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication.Models.Database;

namespace WebApplication.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WebApplication.Models.Database.Mod", b =>
            {
                b.Property<string>("Id")
                    .HasColumnType("text");

                b.Property<string>("Name")
                    .HasColumnType("text");

                b.Property<string>("ForumUrl")
                    .HasColumnType("text");

                b.Property<string>("SteamUrl")
                    .HasColumnType("text");

                b.HasKey("Id", "Name");

                b.HasAlternateKey("Id");

                b.ToTable("Mod");
            });

            modelBuilder.Entity("WebApplication.Models.Database.ModList", b =>
            {
                b.Property<string>("Id")
                    .HasColumnType("text");

                b.Property<string>("Author")
                    .HasColumnType("text");

                b.Property<DateTime>("CreationDate")
                    .HasColumnType("timestamp without time zone");

                b.HasKey("Id");

                b.ToTable("ModList");
            });

            modelBuilder.Entity("WebApplication.Models.Database.ModListMod", b =>
            {
                b.Property<string>("ModListId")
                    .HasColumnType("text");

                b.Property<string>("ModId")
                    .HasColumnType("text");

                b.Property<string>("ModName")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("ModListId", "ModId");

                b.HasIndex("ModId", "ModName");

                b.ToTable("ModListMod");
            });

            modelBuilder.Entity("WebApplication.Models.Database.ModListMod", b =>
            {
                b.HasOne("WebApplication.Models.Database.ModList", "ModList")
                    .WithMany("Mods")
                    .HasForeignKey("ModListId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("WebApplication.Models.Database.Mod", "Mod")
                    .WithMany("ModLists")
                    .HasForeignKey("ModId", "ModName")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}