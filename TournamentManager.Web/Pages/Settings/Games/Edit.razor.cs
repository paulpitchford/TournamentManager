using Microsoft.AspNetCore.Components;
using System.Text.Json;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.Games
{
    public partial class Edit
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navManager { get; set; } = default!;

        [Parameter]
        public Guid Id { get; set; }
        Game? Game { get; set; }
        IEnumerable<Season>? Seasons { get; set; }
        IEnumerable<GameType>? GameTypes { get; set; }
        IEnumerable<Venue>? Venues { get; set; }    
        IEnumerable<Player>? Players { get; set; }

        Player? NewPlayer { get; set; } = new Player();

        bool formLoading;

        protected override async Task OnInitializedAsync()
        {
            formLoading = true;
            Game = await _apiClient.httpClient.GetFromJsonAsync<Game>($"/api/Games/{Id}");

            Seasons = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<Season>>("/api/Seasons/");
            GameTypes = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<GameType>>("/api/GameTypes/");
            Venues = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<Venue>>("/api/Venues/");
            Players = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<Player>>("/api/Players");
            formLoading = false;
        }

        async Task OnSubmit()
        {
            if (Game != null)
            {
                try
                {
                    var response = await _apiClient.httpClient.PutAsJsonAsync<Game>($"/api/Games/{Id}", Game);
                    bool updated = await response.Content.ReadFromJsonAsync<bool>();

                    if (updated)
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
        }

        void OnCancel()
        {
            _navManager.NavigateTo("/settings/games");
        }

        async Task SubmitPlayer()
        {
            // Save the player
            if (NewPlayer != null)
            {
                var response = await _apiClient.httpClient.PostAsJsonAsync<Player>("/api/Players/", NewPlayer);
                int playerId = await response.Content.ReadFromJsonAsync<int>();
                if (playerId > 0)
                {
                    // Refresh the player list
                    Players = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<Player>>("/api/Players");
                    NewPlayer = new Player();
                }
            }
        }
    }
}
