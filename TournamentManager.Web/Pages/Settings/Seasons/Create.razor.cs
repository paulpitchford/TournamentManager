﻿using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.Seasons
{
    public partial class Create
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navManager { get; set; } = default!;

        Season Season { get; set; } = new();
        IEnumerable<PointStructure>? PointStructures { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Season = new Season { StartDate = DateTime.Today };
            PointStructures = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<PointStructure>>("/api/PointStructures/");
        }

        async Task OnSubmit()
        {
            var response = await _apiClient.httpClient.PostAsJsonAsync<Season>("/api/Seasons/", Season);

            if (response.IsSuccessStatusCode)
            {
                int seasonId = await response.Content.ReadFromJsonAsync<int>();
                if (seasonId > 0)
                {
                    _navManager.NavigateTo("/settings/seasons");
                }
            }
            else
            {
                AlertIsVisible = true;
                Message = await response.Content.ReadAsStringAsync();
                MessageType = AlertMessageType.Danger;
            }
        }

        void OnCancel()
        {
            _navManager.NavigateTo("/settings/seasons");
        }
    }
}
