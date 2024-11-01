using System.Text.Json.Serialization;
namespace Kartverk.Mvc.Models;

public class KommuneInfoViewModel
{
    public string? Fylkesnavn { get; set; }
    public string? Fylkesnummer { get; set; }
    public string? Kommunenavn { get; set; }
    public string? Kommunenummer { get; set; }
}