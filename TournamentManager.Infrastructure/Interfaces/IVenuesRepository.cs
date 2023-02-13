using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Interfaces
{
    public interface IVenuesRepository : IGenericRepository<Venue>
    {
        IEnumerable<Venue> GetAllAscending();
    }
}
