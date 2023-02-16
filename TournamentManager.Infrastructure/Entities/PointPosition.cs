using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentManager.Infrastructure.Enums;

namespace TournamentManager.Infrastructure.Entities
{
    public class PointPosition
    {
        public Guid Id { get; set; }
        public Guid? PointStructureId { get; set; }
        public int Position { get; set; }
        // The admin will set the points value for example for places 1-9. If points should be awarded for places outside 1-9 for turning up,
        // then the default points should be set on the points structure entity
        public double Points { get; set; }
        // PlayerCount or Value
        public PointPositionMultiplierType MultiplierType { get; set; }
        // If value is selected then this multiplier is used. Therefore the points on the results would be (points * player count) or (points * multiplier value)
        public double MultiplierValue { get; set; }

        public virtual PointStructure? PointStructure {get;set;}
    }
}
