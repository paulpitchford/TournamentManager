using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.Players
{
    public partial class Index
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navigationManager { get; set; } = default!;

        bool gridLoading;
        IEnumerable<Player>? Players;
        Player? selectedPlayer;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                gridLoading = true;
                Players = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<Player>>("/api/Players/");
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

        void CreateNew()
        {
            _navigationManager.NavigateTo("/settings/players/create");
        }

        void Edit(Guid Id)
        {
            _navigationManager.NavigateTo($"/settings/players/{Id}");
        }
    }
}
