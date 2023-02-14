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

            Games = new GamesRepository(context);
            GameTypes = new GameTypesRepository(_context);
            Players = new PlayersRepository(_context);
            Results = new ResultsRepository(_context); 
            Seasons = new SeasonsRepository(_context);
            Venues = new VenuesRepository(_context);  
        }

        public IGamesRepository Games { get; set; }
        public IGameTypesRepository GameTypes { get; set; }
        public IPlayersRepository Players { get; set; }
        public IResultsRepository Results { get; set; }
        public ISeasonsRepository Seasons  { get; private set; }
        public IVenuesRepository Venues { get; set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            // TODO: Manage index errors where we're set up unique identifiers
            return _context.SaveChanges();
        }
    }
}
