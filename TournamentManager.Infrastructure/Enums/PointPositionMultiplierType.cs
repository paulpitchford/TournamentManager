using System.ComponentModel.DataAnnotations;

namespace TournamentManager.Infrastructure.Enums
{
    public enum PointPositionMultiplierType
    {
        [Display(Name= "Player Count")]
        PlayerCount,
        [Display(Name = "Multiplier Value")]
        MultiplierValue
    }
}
