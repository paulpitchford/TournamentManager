using TournamentManager.Infrastructure.Interfaces;
using TournamentManager.DataAccess.Repository;

namespace TournamentManager.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private PokerDbContext _context;

        public UnitOfWork(PokerDbContext context)
        {
            _context = context;
            Season = new SeasonRepository(_context);
            GameType = new GameTypeRepository(_context);
            Venue = new VenueRepository(_context);  
        }

        public ISeasonRepository Season  { get; private set; }
        public IGameTypeRepository GameType { get; set; }
        public IVenueRepository Venue { get; set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
