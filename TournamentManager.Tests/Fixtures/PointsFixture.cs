using TournamentManager.Infrastructure.BusinessLogic;

namespace TournamentManager.Tests.Fixtures
{

    public class PointsFixture
    {
        public Position Points { get; set; }

        public PointsFixture()
        {
            Points = new Position();
        }
    }
}
