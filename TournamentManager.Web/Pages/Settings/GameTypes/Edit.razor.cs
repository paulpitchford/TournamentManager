using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.GameTypes
{
    public partial class Edit
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navManager { get; set; } = default!;

        [Parameter]
        public Guid Id { get; set; }
        GameType? GameType { get; set; }
        bool formLoading;

        protected override async Task OnInitializedAsync()
        {
            formLoading = true;
            GameType = await _apiClient.httpClient.GetFromJsonAsync<GameType>($"/api/GameTypes/{Id}");
            formLoading = false;
        }

        async Task OnSubmit()
        {
            if (GameType != null)
            {
                var response = await _apiClient.httpClient.PutAsJsonAsync<GameType>($"/api/GameTypes/{Id}", GameType);

                if (response.IsSuccessStatusCode)
                {
                    _navManager.NavigateTo("/settings/gametypes");
                }
                else
                {
                    AlertIsVisible = true;
                    Message = await response.Content.ReadAsStringAsync();
                    MessageType = AlertMessageType.Danger;
                }
            }
        }

        void OnCancel()
        {
            _navManager.NavigateTo("/settings/gametypes");
        }
    }
}
