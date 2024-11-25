using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

// Modell for håndtering av Hjemmesiden.
public class HomeViewModel
{
    // Vise melding i visningen.
    public string? Message { get; set; }
    
    // Obligatorisk felt for ny melding.
    [Required]
    [DisplayName("Ny melding")]
    public string? NewMessage { get; set; }
    
    // Skjult verdi for å sende data til serveren.
    public string? Hidden { get; set; }
}
