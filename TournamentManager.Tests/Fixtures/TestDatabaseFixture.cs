using Microsoft.EntityFrameworkCore;
using TournamentManager.DataAccess;

namespace TournamentManager.Tests.Fixtures
{
    public class TestDatabaseFixture
    {
        // Test data connection string
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=PokerDbTests;Trusted_Connection=True";

        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public TestDatabaseFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (PokerDbContext context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        // Important to note that when the database is created here it uses the same seed data as the 'Production Db'
                        context.Database.EnsureCreated();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public PokerDbContext CreateContext()
        {
            return new PokerDbContext(new DbContextOptionsBuilder<PokerDbContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);
        }
    }
}
