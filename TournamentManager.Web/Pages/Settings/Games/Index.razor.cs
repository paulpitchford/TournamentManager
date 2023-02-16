using Blazorise;
using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.Games
{
    public partial class Index
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navigationManager { get; set; } = default!;

        bool gridLoading;
        IEnumerable<Game>? Games;
        IEnumerable<GameType>? GameTypes { get; set; }
        IEnumerable<Venue>? Venues { get; set; }
        Game? selectedGame;

        IEnumerable<Season>? Seasons;
        Guid? SelectedSeasonId;
        Guid? SelectedGameTypeId { get; set; }
        Guid? SelectedVenueId { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                gridLoading = true;
                Seasons = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<Season>>("/api/Seasons/");
                GameTypes = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<GameType>>("/api/GameTypes/");
                Venues = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<Venue>>("/api/Venues/");
                await FilterGrid();
                gridLoading = false;
            }
            catch (Exception ex)
            {
                gridLoading = false;
                AlertIsVisible = true;
                Message = ex.Message;
                MessageType = AlertMessageType.Danger;
            }
        }

        async Task FilterGrid()
        {
            if (SelectedSeasonId == null)
            {
                if (Seasons != null)
                {
                    SelectedSeasonId = Seasons.First().Id;
                }
            }

            Games = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<Game>>($"/api/Games/");

            if (Games != null)
            {
                if (SelectedSeasonId != null)
                {
                    Games = Games.Where(q => q.SeasonId == SelectedSeasonId).ToList();
                }

                if (SelectedGameTypeId != null)
                {
                    Games = Games.Where(q => q.GameTypeId == SelectedGameTypeId).ToList();
                }

                if (SelectedVenueId != null)
                {
                    Games = Games.Where(q => q.VenueId == SelectedVenueId).ToList();
                }
            }
        }

        void CreateNew()
        {
            _navigationManager.NavigateTo("/settings/games/create");
        }

        void Edit(Guid Id)
        {
            _navigationManager.NavigateTo($"/settings/games/{Id}");
        }

        async Task OnSeasonChanged()
        {
            await FilterGrid();
        }
    }
}
