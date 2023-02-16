using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Infrastructure.Entities
{
    public class GameType
    {
        public Guid Id { get; set; }
        public string? GameTypeName { get; set; }
        public bool AwardPoints { get; set; }

        // Primarily there will be a more popular game type. Here we can set the default game type to aid adding new games.
        public bool IsDefault { get; set; }

        public ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}
