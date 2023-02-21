using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.Seasons
{
    public partial class Edit
    {
        [Inject] 
        WebApiService _apiClient { get; set; } = default!;

        [Inject] 
        NavigationManager _navManager { get; set; } = default!;
        
        [Parameter]
        public Guid Id { get; set; }
        Season? Season { get; set; }
        IEnumerable<PointStructure>? PointStructures { get; set; }
        bool formLoading;

        protected override async Task OnInitializedAsync()
        {
            formLoading = true;
            Season = await _apiClient.httpClient.GetFromJsonAsync<Season>($"/api/Seasons/{Id}");
            PointStructures = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<PointStructure>>("/api/PointStructures/");
            formLoading = false;
        }

        async Task OnSubmit()
        {
            if (Season != null)
            {
                var response = await _apiClient.httpClient.PutAsJsonAsync<Season>($"/api/Seasons/{Id}", Season);

                if (response.IsSuccessStatusCode)
                {
                    _navManager.NavigateTo("/settings/seasons");
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
            _navManager.NavigateTo("/settings/seasons");
        }
    }
}
