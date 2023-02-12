﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TournamentManager.DataAccess;

#nullable disable

namespace TournamentManager.DataAccess.Migrations
{
    [DbContext(typeof(PokerDbContext))]
    partial class PokerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TournamentManager.Infrastructure.Entities.GameType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AwardPoints")
                        .HasColumnType("bit");

                    b.Property<string>("GameTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("GameTypeName")
                        .IsUnique();

                    b.ToTable("GameTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"),
                            AwardPoints = true,
                            GameTypeName = "League"
                        },
                        new
                        {
                            Id = new Guid("6117db2a-2143-460d-a5cf-7d038caa3c33"),
                            AwardPoints = false,
                            GameTypeName = "Final"
                        },
                        new
                        {
                            Id = new Guid("0bd6aac9-ad90-4fdb-9725-ae363f0d9171"),
                            AwardPoints = false,
                            GameTypeName = "Special"
                        });
                });

            modelBuilder.Entity("TournamentManager.Infrastructure.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TournamentDirectorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TournamentDirectorId")
                        .IsUnique()
                        .HasFilter("[TournamentDirectorId] IS NOT NULL");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = new Guid("644d7d1a-57d1-4e70-9963-376369fa73cd"),
                            FirstName = "Paul",
                            LastName = "Pitchford",
                            TournamentDirectorId = new Guid("2f5bafda-b39e-4b87-84af-73f92b1dfecc")
                        },
                        new
                        {
                            Id = new Guid("02f03bbe-dcc3-47c6-bc17-a0dc30822f57"),
                            FirstName = "Adam",
                            LastName = "May"
                        },
                        new
                        {
                            Id = new Guid("f9288114-38dc-445f-ae86-603841f4eca7"),
                            FirstName = "Niamh",
                            LastName = "Warren"
                        },
                        new
                        {
                            Id = new Guid("496f54f9-ab0c-4fd8-8ef5-f09fb1f09dd5"),
                            FirstName = "Malakai",
                            LastName = "Davidson"
                        },
                        new
                        {
                            Id = new Guid("74b97573-79a4-487e-9b26-8c4020f8b395"),
                            FirstName = "Saul",
                            LastName = "Pena"
                        },
                        new
                        {
                            Id = new Guid("d590a981-5caf-4416-83d2-36f5defdd89e"),
                            FirstName = "Fleur",
                            LastName = "Gray"
                        },
                        new
                        {
                            Id = new Guid("99c65e3f-4a41-45c3-ac7d-f6593b2f72c0"),
                            FirstName = "Nevaeh",
                            LastName = "Hatfield"
                        },
                        new
                        {
                            Id = new Guid("916d616d-a760-4a60-8524-bed87bee4411"),
                            FirstName = "Layla",
                            LastName = "Russell"
                        },
                        new
                        {
                            Id = new Guid("50432083-d2c4-4123-b6f7-c5a5d8103928"),
                            FirstName = "Priya",
                            LastName = "Arroyo"
                        },
                        new
                        {
                            Id = new Guid("26b843f6-0af6-40c2-b7be-4320b6232bf0"),
                            FirstName = "Trinity",
                            LastName = "Lin"
                        });
                });

            modelBuilder.Entity("TournamentManager.Infrastructure.Entities.Season", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SeasonName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SeasonName")
                        .IsUnique();

                    b.ToTable("Seasons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"),
                            SeasonName = "Season One",
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("7a0cf45d-7423-4aea-b7a5-aa0c571d5b05"),
                            SeasonName = "Season Two",
                            StartDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("e007944b-bda8-42bf-9d1e-1d7894f98ff5"),
                            SeasonName = "Season Three",
                            StartDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("TournamentManager.Infrastructure.Entities.Venue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ExtraInformation")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FacebookAddress")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VenueName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("WebAddress")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("VenueName")
                        .IsUnique();

                    b.ToTable("Venues");

                    b.HasData(
                        new
                        {
                            Id = new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d"),
                            Address = "High Pavement",
                            County = "Nottinghamshire",
                            PostCode = "NG17 4BA",
                            Town = "Sutton in Ashfield",
                            VenueName = "The Devonshire Arms"
                        },
                        new
                        {
                            Id = new Guid("cb29fe0d-e42c-4a8a-9ab9-839caeb9d4ea"),
                            Address = "High Pavement",
                            County = "Nottinghamshire",
                            PostCode = "NG17 4BD",
                            Town = "Sutton in Ashfield",
                            VenueName = "Josephs Club"
                        },
                        new
                        {
                            Id = new Guid("ae24627e-9e05-4529-b6ff-5917d6b8038e"),
                            Address = "Sutton Road",
                            County = "Nottinghamshire",
                            PostCode = "NG17 7GZ",
                            Town = "Kirkby in Ashfield",
                            VenueName = "Bentinck Social Club"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
