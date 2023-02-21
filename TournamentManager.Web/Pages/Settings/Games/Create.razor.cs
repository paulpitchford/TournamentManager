using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.Games
{
    public partial class Create
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navManager { get; set; } = default!;

        Game Game { get; set; } = new Game { GameDateTime = DateTime.Now };
        IEnumerable<Season>? Seasons { get; set; }
        IEnumerable<GameType>? GameTypes { get; set; }
        IEnumerable<Venue>? Venues { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Seasons = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<Season>>("/api/Seasons/");
            GameTypes = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<GameType>>("/api/GameTypes/");
            Venues = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<Venue>>("/api/Venues/");

            // We're probably going to be entering games for the newsest season in the database from the list of seasons above.
            if (Seasons != null)
            {
                // They're in date descending order, so just take the first.
                Game.SeasonId = Seasons.First().Id;
            }

            // Get the current set default game type
            if (GameTypes != null)
            {
                // There will be 0 or 1 results due to the unique constraint in the DbContext for IsDefault
                GameType? gameType = GameTypes.Where(gt => gt.IsDefault).FirstOrDefault();
                if (gameType != null)
                {
                    Game.GameTypeId= gameType.Id;
                }
            }
        }

        async Task OnSubmit()
        {
            var response = await _apiClient.httpClient.PostAsJsonAsync<Game>("/api/Games/", Game);

            if (response.IsSuccessStatusCode)
            {
                int gameId = await response.Content.ReadFromJsonAsync<int>();
                if (gameId > 0)
                {
                    _navManager.NavigateTo($"/settings/games/season/{Game.SeasonId}");
                }
            }
            else
            {
                AlertIsVisible = true;
                Message = await response.Content.ReadAsStringAsync();
                MessageType = AlertMessageType.Danger;
            }
        }

        void OnCancel()
        {
            _navManager.NavigateTo("/settings/games");
        }
    }
}
