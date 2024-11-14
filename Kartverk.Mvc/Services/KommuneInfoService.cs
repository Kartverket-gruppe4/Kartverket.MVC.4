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
        
        // Logger for logging av informasjon og feil.
        private readonly ILogger<KommuneInfoService> _logger;
        
        // API-innstillinger for å hente basen URL fra konfigurasjonsfilene.
        private readonly ApiSettings _apiSettings;

        // Konstruktør som initialiserer de nødvendige tjenestene.
        public KommuneInfoService(HttpClient httpClient, ILogger<KommuneInfoService> logger, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _logger = logger;
            _apiSettings = apiSettings.Value; // Leser inn API-innstillinger fra konfigurasjonen.
        }

        // Asynkron metode for å hente kommuneinformasjon basert på geografiske koordinater.
        public async Task<KommuneInfo> GetKommuneInfoAsync(double latitude, double longitude)
        {
            try
            {
                // Bygger URL-en for API-anropet ved å bruke base URL og koordinater.
                // "nord" representerer breddegrad og "ost" representerer lengdegrad.
                var url = $"{_apiSettings.KommuneInfoApiBaseUrl}/punkt?nord={latitude.ToString(CultureInfo.InvariantCulture)}&ost={longitude.ToString(CultureInfo.InvariantCulture)}&koordsys=4326";

                // Utfører et asynkront GET-anrop til API-et.
                var response = await _httpClient.GetAsync(url);
                
                // Forsikrer at API-anropet var vellykket (statuskode 2xx).
                response.EnsureSuccessStatusCode();

                // Leser svarinnholdet som en streng (JSON-format).
                var json = await response.Content.ReadAsStringAsync();
                _logger.LogInformation($"KommuneInfo Response: {json}"); // Logger svaret for debugging.

                // Deserialiserer JSON-responsen til et KommuneInfo-objekt.
                var kommuneInfo = JsonSerializer.Deserialize<KommuneInfo>(json);
                
                // Returnerer den deserialiserte kommuneinformasjonen.
                return kommuneInfo;
            }
            catch (Exception ex)
            {
                // Logger eventuelle feil som oppstår under API-anropet.
                _logger.LogError($"Error fetching KommuneInfo for coordinates ({latitude}, {longitude}): {ex.Message}");
                
                // Returnerer null hvis det oppstår en feil.
                return null;
            }
        }
    }
}
