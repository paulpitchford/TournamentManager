using Microsoft.EntityFrameworkCore;
using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.DataAccess
{
    public class PokerDbContext : DbContext
    {
        public PokerDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Season> Seasons { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<Venue> Venues { get; set; }

        // Seed the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Season
            modelBuilder.Entity<Season>().Property(s => s.SeasonName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Season>().Property(s => s.StartDate).IsRequired();
            modelBuilder.Entity<Season>().HasIndex(s => s.SeasonName).IsUnique();
            modelBuilder.Entity<Season>().HasData
            (
                new Season
                {
                    Id = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"),
                    SeasonName = "Season One",
                    StartDate = new DateTime(2021, 1, 1)
                },
                new Season
                {
                    Id = new Guid("7a0cf45d-7423-4aea-b7a5-aa0c571d5b05"),
                    SeasonName = "Season Two",
                    StartDate = new DateTime(2022, 1, 1)
                }, new Season
                {
                    Id = new Guid("e007944b-bda8-42bf-9d1e-1d7894f98ff5"),
                    SeasonName = "Season Three",
                    StartDate = new DateTime(2023, 1, 1)
                }
            );
            #endregion

            #region GameType
            modelBuilder.Entity<GameType>().Property(s => s.GameTypeName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<GameType>().Property(s => s.AwardPoints).IsRequired();
            modelBuilder.Entity<GameType>().HasIndex(s => s.GameTypeName).IsUnique();
            modelBuilder.Entity<GameType>().HasData
            (
                new GameType
                { 
                    Id = new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"),
                    GameTypeName = "League",
                    AwardPoints = true
                },
                new GameType
                {
                    Id = new Guid("6117db2a-2143-460d-a5cf-7d038caa3c33"),
                    GameTypeName = "Final",
                    AwardPoints = false
                },
                new GameType
                {
                    Id = new Guid("0bd6aac9-ad90-4fdb-9725-ae363f0d9171"),
                    GameTypeName = "Special",
                    AwardPoints = false
                }
            );
            #endregion

            #region Venue
            modelBuilder.Entity<Venue>().Property(v => v.VenueName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Venue>().Property(v => v.Address).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Venue>().Property(v => v.Town).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Venue>().Property(v => v.County).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Venue>().Property(v => v.PostCode).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Venue>().Property(v => v.PhoneNumber).HasMaxLength(50);
            modelBuilder.Entity<Venue>().Property(v => v.WebAddress).HasMaxLength(255);
            modelBuilder.Entity<Venue>().Property(v => v.FacebookAddress).HasMaxLength(255);
            modelBuilder.Entity<Venue>().Property(v => v.ExtraInformation).HasMaxLength(255);
            modelBuilder.Entity<Venue>().HasIndex(s => s.VenueName).IsUnique();
            modelBuilder.Entity<Venue>().HasData
            (
                new Venue
                {
                    Id = new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d"),
                    VenueName = "The Devonshire Arms",
                    Address = "High Pavement",
                    Town = "Sutton in Ashfield",
                    County = "Nottinghamshire",
                    PostCode = "NG17 4BA"
                }, new Venue
                {
                    Id = new Guid("cb29fe0d-e42c-4a8a-9ab9-839caeb9d4ea"),
                    VenueName = "Josephs Club",
                    Address = "High Pavement",
                    Town = "Sutton in Ashfield",
                    County = "Nottinghamshire",
                    PostCode = "NG17 4BD"
                }, new Venue
                {
                    Id = new Guid("ae24627e-9e05-4529-b6ff-5917d6b8038e"),
                    VenueName = "Bentinck Social Club",
                    Address = "Sutton Road",
                    Town = "Kirkby in Ashfield",
                    County = "Nottinghamshire",
                    PostCode = "NG17 7GZ"
                }
            );
            #endregion
        }
    }
}
