namespace Kartverk.Mvc.Models;

// Modell for Kommuneinfo.
public class KommuneInfoViewModel
{
    // Navnet på fylket.
    public string? Fylkesnavn { get; set; }

    // Nummeret på fylket. 
    public string? Fylkesnummer { get; set; }

    // Navnet på kommunen.
    public string? Kommunenavn { get; set; }

    // Nummeret på kommunen.
    public string? Kommunenummer { get; set; } 
}