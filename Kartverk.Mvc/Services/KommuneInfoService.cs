using System.Globalization;
using Kartverk.Mvc.API_Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Kartverk.Mvc.Services
{
    // Implementering av IKommuneInfoService.
    public class KommuneInfoService : IKommuneInfoService
    {
        // HttpClient for å gjøre API-anrop.
        private readonly HttpClient _httpClient;
        
        // Logger for informasjon og feil.
        private readonly ILogger<KommuneInfoService> _logger;
        
        // API-innstillinger fra konfigurasjonsfilene.
        private readonly ApiSettings _apiSettings;

        // Konstruktør som initialiserer de nødvendige tjenestene.
        public KommuneInfoService(HttpClient httpClient, ILogger<KommuneInfoService> logger, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _logger = logger;
            _apiSettings = apiSettings.Value; // Leser inn API-innstillinger fra konfigurasjonen.
        }

        // Henter kommuneinfo basert på koordinater.
        public async Task<KommuneInfo?> GetKommuneInfoAsync(double latitude, double longitude)
        {
            try
            {
                // Bygger URL for API-anrop med koordinater.
                var url = $"{_apiSettings.KommuneInfoApiBaseUrl}/punkt?nord={latitude.ToString(CultureInfo.InvariantCulture)}&ost={longitude.ToString(CultureInfo.InvariantCulture)}&koordsys=4326";

                // Utfører GET-anrop.
                var response = await _httpClient.GetAsync(url);
                
                // Forsikrer at anropet er vellykket.
                response.EnsureSuccessStatusCode();

                // Leser og logger JSON-responsen.
                var json = await response.Content.ReadAsStringAsync();
                _logger.LogInformation($"KommuneInfo Response: {json}"); // Logger svaret for debugging.

                // Deserialiserer JSON til KommuneInfo.
                var kommuneInfo = JsonSerializer.Deserialize<KommuneInfo>(json);
                
                // Returnerer kommuneinformasjonen.
                return kommuneInfo;
            }
            catch (Exception ex)
            {
                // Logger feil ved API-anrop.
                _logger.LogError($"Error fetching KommuneInfo for coordinates ({latitude}, {longitude}): {ex.Message}");
                
                // Returnerer null ved feil.
                return null;
            }
        }
    }
}
