using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.Players
{
    public partial class Edit
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navManager { get; set; } = default!;

        [Parameter]
        public Guid Id { get; set; }
        Player? Player { get; set; }
        bool formLoading;

        protected override async Task OnInitializedAsync()
        {
            formLoading = true;
            Player = await _apiClient.httpClient.GetFromJsonAsync<Player>($"/api/Players/{Id}");
            formLoading = false;
        }

        async Task OnSubmit()
        {
            if (Player != null)
            {
                var response = await _apiClient.httpClient.PutAsJsonAsync<Player>($"/api/Players/{Id}", Player);

                if (response.IsSuccessStatusCode)
                {
                    _navManager.NavigateTo("/settings/players");
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
            _navManager.NavigateTo("/settings/players");
        }
    }
}
