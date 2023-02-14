using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.GameTypes
{
    public partial class Index
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navigationManager { get; set; } = default!;

        bool gridLoading;
        IEnumerable<GameType>? GameTypes;
        GameType? selectedGameType;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                gridLoading = true;
                GameTypes = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<GameType>>("/api/GameTypes/");
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
            _navigationManager.NavigateTo("/settings/gametypes/create");
        }

        void Edit(Guid Id)
        {
            _navigationManager.NavigateTo($"/settings/gametypes/{Id}");
        }
    }
}
