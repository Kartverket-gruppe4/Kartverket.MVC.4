using System.Globalization;
using Kartverk.Mvc.API_Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Kartverk.Mvc.Services;

public class KommuneInfoService : IKommuneInfoService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<KommuneInfoService> _logger;
    private readonly ApiSettings _apiSettings;

    public KommuneInfoService(HttpClient httpClient, ILogger<KommuneInfoService> logger, IOptions<ApiSettings> apiSettings)
    {
        _httpClient = httpClient;
        _logger = logger;
        _apiSettings = apiSettings.Value;
    }

    public async Task<KommuneInfo> GetKommuneInfoAsync(double latitude, double longitude)
    {
        try
        {
            // Bruker 'nord', 'ost', og 'koordsys' som parameternavn
            var url = $"{_apiSettings.KommuneInfoApiBaseUrl}/punkt?nord={latitude.ToString(CultureInfo.InvariantCulture)}&ost={longitude.ToString(CultureInfo.InvariantCulture)}&koordsys=4326";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"KommuneInfo Response: {json}");
            var kommuneInfo = JsonSerializer.Deserialize<KommuneInfo>(json);
            return kommuneInfo;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error fetching KommuneInfo for coordinates ({latitude}, {longitude}): {ex.Message}");
            return null;
        }
    }
}