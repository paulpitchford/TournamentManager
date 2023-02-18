using TournamentManager.Infrastructure.BusinessLogic;

namespace TournamentManager.Tests.Fixtures
{

    public class PositionFactoryFixtures
    {
        public PositionFactory PositionFactory { get; set; }

        public PositionFactoryFixtures()
        {
            PositionFactory = new PositionFactory();
        }
    }
}
