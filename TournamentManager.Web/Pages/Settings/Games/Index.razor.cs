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
        Game? selectedGame;

        IEnumerable<Season>? Seasons;
        Guid? selectedSeasonId;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                gridLoading = true;
                Seasons = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<Season>>("/api/Seasons/");
                await ApplyFilter();
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

        async Task ApplyFilter()
        {
            if (Seasons != null)
            {
                if (selectedSeasonId == null)
                {
                    // The seasons come through in descending order so we just take the first Id
                    selectedSeasonId = Seasons.First().Id;
                }
                Games = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<Game>>($"/api/Games/GetGamesBySeason/{selectedSeasonId}");
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
            await ApplyFilter();
        }
    }
}
