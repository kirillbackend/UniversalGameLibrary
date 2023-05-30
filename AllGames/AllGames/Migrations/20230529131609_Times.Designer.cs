﻿// <auto-generated />
using System;
using AllGames.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AllGames.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230529131609_Times")]
    partial class Times
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AllGames.DataBase.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AllGames.DataBase.Entity.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("LauncherPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("RequiresLauncher")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("AllGames.DataBase.Entity.Time", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GamesId")
                        .HasColumnType("integer");

                    b.Property<int>("Hour")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastLaunch")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Minute")
                        .HasColumnType("integer");

                    b.Property<int>("Second")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GamesId")
                        .IsUnique();

                    b.ToTable("Times");
                });

            modelBuilder.Entity("AllGames.DataBase.Entity.Games", b =>
                {
                    b.HasOne("AllGames.DataBase.Entity.Category", "Category")
                        .WithMany("Games")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AllGames.DataBase.Entity.Time", b =>
                {
                    b.HasOne("AllGames.DataBase.Entity.Games", "Games")
                        .WithOne("Time")
                        .HasForeignKey("AllGames.DataBase.Entity.Time", "GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Games");
                });

            modelBuilder.Entity("AllGames.DataBase.Entity.Category", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("AllGames.DataBase.Entity.Games", b =>
                {
                    b.Navigation("Time");
                });
#pragma warning restore 612, 618
        }
    }
}
