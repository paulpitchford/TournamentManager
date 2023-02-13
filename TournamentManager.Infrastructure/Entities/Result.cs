using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Infrastructure.Entities
{
    public class Result
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public int Position { get; set; }
        public double Cash { get; set; }
        public double Points { get; set; }

        public virtual Game Game { get; set; } = default!;
        public virtual Player Player { get; set; } = default!;
    }
}
