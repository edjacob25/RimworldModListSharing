﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication.Models.Database;

#nullable disable

namespace WebApplication.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20211108230257_Add Ideology")]
    partial class AddIdeology
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "expansions", new[] { "royalty", "ideology" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

                    b.HasIndex("Id");

                    b.ToTable("Mod", (string)null);
                });

            modelBuilder.Entity("WebApplication.Models.Database.ModList", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Author")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<Expansions>>("Expansions")
                        .HasColumnType("expansions[]");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Version")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ModList", (string)null);
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

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.HasKey("ModListId", "ModId");

                    b.HasIndex("ModId", "ModName");

                    b.ToTable("ModListMod", (string)null);
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

                    b.Navigation("Mod");

                    b.Navigation("ModList");
                });

            modelBuilder.Entity("WebApplication.Models.Database.Mod", b =>
                {
                    b.Navigation("ModLists");
                });

            modelBuilder.Entity("WebApplication.Models.Database.ModList", b =>
                {
                    b.Navigation("Mods");
                });
#pragma warning restore 612, 618
        }
    }
}