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
                try
                {
                    var response = await _apiClient.httpClient.PutAsJsonAsync<Season>($"/api/Seasons/{Id}", Season);
                    bool updated = await response.Content.ReadFromJsonAsync<bool>();

                    if (updated)
                    {
                        _navManager.NavigateTo("/settings/seasons");
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
            _navManager.NavigateTo("/settings/seasons");
        }
    }
}
