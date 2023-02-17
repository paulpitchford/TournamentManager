namespace TournamentManager.Infrastructure.Exceptions
{
    public class SortedPositionListContainsZeroException : Exception
    {
        public SortedPositionListContainsZeroException()
        {

        }

        public SortedPositionListContainsZeroException(string message) : base (message) { }
    }
}
