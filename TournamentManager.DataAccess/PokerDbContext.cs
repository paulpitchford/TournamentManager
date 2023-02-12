using Microsoft.EntityFrameworkCore;
using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.DataAccess
{
    public class PokerDbContext : DbContext
    {
        public PokerDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Season> Seasons { get; set; }

        // Seed the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
}
