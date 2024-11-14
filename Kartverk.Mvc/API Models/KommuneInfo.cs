using System.Text.Json.Serialization;

namespace Kartverk.Mvc.API_Models;

// Klassen `KommuneInfo` representerer informasjon om en kommune.
public class KommuneInfo
{
    // Definerer egenskapen `Fylkesnavn`, som holder navnet på fylket.
    [JsonPropertyName("fylkesnavn")]
    public string? Fylkesnavn { get; set; }

    // Egenskapen `Fylkesnummer` lagrer fylkets nummer som en tekststreng.
    [JsonPropertyName("fylkesnummer")]
    public string? Fylkesnummer { get; set; }

    // `Kommunenavn` lagrer navnet på kommunen.
    [JsonPropertyName("kommunenavn")]
    public string? Kommunenavn { get; set; }

    // `Kommunenummer` lagrer kommunens unike nummer.
    [JsonPropertyName("kommunenummer")]
    public string? Kommunenummer { get; set; }
}

