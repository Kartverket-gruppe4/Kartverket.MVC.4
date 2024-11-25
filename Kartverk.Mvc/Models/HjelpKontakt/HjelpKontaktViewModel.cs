namespace Kartverk.Mvc.Models.HjelpKontakt;

// Modell for Hjelp og Kontakt-skjema.
public class HjelpKontaktViewModel
{
    // Brukerens navn.
    public string? Name { get; set; }
    
    // Brukerens e-post.
    public string? Email { get; set; }
    
    // Meldingen brukeren ønsker å sende.
    public string? Message { get; set; }
    
}