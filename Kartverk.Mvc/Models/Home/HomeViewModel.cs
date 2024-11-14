using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class HomeViewModel
{
    // En egenskap for å vise en melding i visningen. 
    public string? Message { get; set; }
    
    // Egenskap som representerer en ny melding som brukeren kan skrive inn.
    // [Required] gjør at det er et obligatorisk felt i skjemaet.
    // [DisplayName("Ny melding")] spesifiserer at labelen i skjemaet skal være "Ny melding".
    [Required]
    [DisplayName("Ny melding")]
    public string? NewMessage { get; set; }
    
    // Egenskap for å holde på en skjult verdi som kan brukes til å sende data til serveren uten at det vises i skjemaet.
    public string? Hidden { get; set; }
}
