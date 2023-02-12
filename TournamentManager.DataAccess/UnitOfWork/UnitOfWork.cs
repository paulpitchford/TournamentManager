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
            GameType = new GameTypeRepository(_context);
            Player = new PlayerRepository(_context);
            Season = new SeasonRepository(_context);
            Venue = new VenueRepository(_context);  
        }

        public IGameTypeRepository GameType { get; set; }
        public IPlayerRepository Player { get; set; }
        public ISeasonRepository Season  { get; private set; }
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
