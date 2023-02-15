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
        }

        async Task OnSubmit()
        {
            try
            {
                var response = await _apiClient.httpClient.PostAsJsonAsync<Game>("/api/Games/", Game);
                int gameId = await response.Content.ReadFromJsonAsync<int>();
                if (gameId > 0)
                {
                    _navManager.NavigateTo("/settings/games");
                }
            }
            catch (Exception ex)
            {
                AlertIsVisible = true;
                Message = ex.Message;
                MessageType = AlertMessageType.Danger;
            }
        }

        void OnCancel()
        {
            _navManager.NavigateTo("/settings/games");
        }
    }
}
