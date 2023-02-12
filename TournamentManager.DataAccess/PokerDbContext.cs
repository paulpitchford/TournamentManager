using Microsoft.EntityFrameworkCore;
using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.DataAccess
{
    public class PokerDbContext : DbContext
    {
        public PokerDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Season> Seasons { get; set; }
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

            #region Player
            modelBuilder.Entity<Player>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.LastName).IsRequired();
            modelBuilder.Entity<Player>().HasIndex(s => s.TournamentDirectorId).IsUnique();
            modelBuilder.Entity<Player>().HasData
            (
                new Player
                {
                    Id = new Guid("644d7d1a-57d1-4e70-9963-376369fa73cd"),
                    FirstName = "Paul",
                    LastName = "Pitchford",
                    TournamentDirectorId = new Guid("2f5bafda-b39e-4b87-84af-73f92b1dfecc")
                }, 
                new Player
                {
                    Id = new Guid("02f03bbe-dcc3-47c6-bc17-a0dc30822f57"),
                    FirstName = "Adam",
                    LastName = "May"
                },
                new Player
                {
                    Id = new Guid("f9288114-38dc-445f-ae86-603841f4eca7"),
                    FirstName = "Niamh",
                    LastName = "Warren"
                },
                new Player
                {
                    Id = new Guid("496f54f9-ab0c-4fd8-8ef5-f09fb1f09dd5"),
                    FirstName = "Malakai",
                    LastName = "Davidson"
                },
                new Player
                {
                    Id = new Guid("74b97573-79a4-487e-9b26-8c4020f8b395"),
                    FirstName = "Saul",
                    LastName = "Pena"
                },
                new Player
                {
                    Id = new Guid("d590a981-5caf-4416-83d2-36f5defdd89e"),
                    FirstName = "Fleur",
                    LastName = "Gray"
                },
                new Player
                {
                    Id = new Guid("99c65e3f-4a41-45c3-ac7d-f6593b2f72c0"),
                    FirstName = "Nevaeh",
                    LastName = "Hatfield"
                },
                new Player
                {
                    Id = new Guid("916d616d-a760-4a60-8524-bed87bee4411"),
                    FirstName = "Layla",
                    LastName = "Russell"
                },
                new Player
                {
                    Id = new Guid("50432083-d2c4-4123-b6f7-c5a5d8103928"),
                    FirstName = "Priya",
                    LastName = "Arroyo"
                },
                new Player
                {
                    Id = new Guid("26b843f6-0af6-40c2-b7be-4320b6232bf0"),
                    FirstName = "Trinity",
                    LastName = "Lin"
                }
            );
            #endregion

            #region Game
            modelBuilder.Entity<Game>().Property(g => g.SeasonId).IsRequired();
            modelBuilder.Entity<Game>().Property(g => g.GameTypeId).IsRequired();
            modelBuilder.Entity<Game>().Property(g => g.VenueId).IsRequired();
            modelBuilder.Entity<Game>().Property(g => g.GameTitle).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Game>().Property(g => g.GameDateTime).IsRequired();
            modelBuilder.Entity<Game>().Property(g => g.PublishResults).IsRequired();
            modelBuilder.Entity<Game>().Property(g => g.GameDetails).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Game>().Property(g => g.Buyin).IsRequired();
            modelBuilder.Entity<Game>().Property(g => g.Fee).IsRequired();
            modelBuilder.Entity<Game>().HasOne(g => g.Season).WithMany(s => s.Games).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Game>().HasOne(g => g.GameType).WithMany(s => s.Games).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Game>().HasOne(g => g.Venue).WithMany(s => s.Games).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Game>().HasData
            (
                new Game
                {
                    Id = new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be"),
                    SeasonId = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"),
                    GameTypeId = new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"),
                    VenueId = new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d"),
                    GameTitle = "Game 1",
                    GameDateTime = new DateTime(2021, 1, 1, 14, 30, 0),
                    PublishResults = false,
                    GameDetails = "League game 1, £40 buy in.",
                    Buyin = 35d,
                    Fee = 5d
                },
                new Game
                {
                    Id = new Guid("ff143321-2b4b-4b7b-adf3-57dc0beec786"),
                    SeasonId = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"),
                    GameTypeId = new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"),
                    VenueId = new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d"),
                    GameTitle = "Game 2",
                    GameDateTime = new DateTime(2021, 2, 1, 14, 30, 0),
                    PublishResults = false,
                    GameDetails = "League game 2, £40 buy in.",
                    Buyin = 35d,
                    Fee = 5d
                },
                new Game
                {
                    Id = new Guid("85eaff7b-dd27-4e43-8976-f10eb415bf61"),
                    SeasonId = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"),
                    GameTypeId = new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"),
                    VenueId = new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d"),
                    GameTitle = "Game 3",
                    GameDateTime = new DateTime(2021, 3, 1, 14, 30, 0),
                    PublishResults = false,
                    GameDetails = "League game 3, £40 buy in.",
                    Buyin = 35d,
                    Fee = 5d
                },
                new Game
                {
                    Id = new Guid("c9a29408-0b4e-44a8-8a23-c51ddb8b360a"),
                    SeasonId = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"),
                    GameTypeId = new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"),
                    VenueId = new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d"),
                    GameTitle = "Game 4",
                    GameDateTime = new DateTime(2021, 4, 1, 14, 30, 0),
                    PublishResults = false,
                    GameDetails = "League game 4, £40 buy in.",
                    Buyin = 35d,
                    Fee = 5d
                },
                new Game
                {
                    Id = new Guid("c08c4989-8d4f-4729-a27d-f762f768cc59"),
                    SeasonId = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"),
                    GameTypeId = new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"),
                    VenueId = new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d"),
                    GameTitle = "Game 5",
                    GameDateTime = new DateTime(2021, 5, 1, 14, 30, 0),
                    PublishResults = false,
                    GameDetails = "League game 5, £40 buy in.",
                    Buyin = 35d,
                    Fee = 5d
                },
                new Game
                {
                    Id = new Guid("87450acd-ca09-40c2-883b-aad03402f9dc"),
                    SeasonId = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"),
                    GameTypeId = new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"),
                    VenueId = new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d"),
                    GameTitle = "Game 6",
                    GameDateTime = new DateTime(2021, 6, 1, 14, 30, 0),
                    PublishResults = false,
                    GameDetails = "League game 6, £40 buy in.",
                    Buyin = 35d,
                    Fee = 5d
                }
            );
            #endregion
        }
    }
}
