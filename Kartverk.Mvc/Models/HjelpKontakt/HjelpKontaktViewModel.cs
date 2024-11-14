namespace Kartverk.Mvc.Models.HjelpKontakt;

// ViewModel for Hjelp og Kontakt-skjema.
public class HjelpKontaktViewModel
{
    // Brukerens navn (kan være tomt eller null).
    public string Name { get; set; }
    
    // Brukerens e-post (kan være tomt eller null).
    public string Email { get; set; }
    
    // Meldingen brukeren ønsker å sende (kan være tomt eller null).
    public string Message { get; set; }
    
}