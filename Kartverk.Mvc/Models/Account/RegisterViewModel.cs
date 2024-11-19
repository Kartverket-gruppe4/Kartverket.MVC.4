using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required] // Gjør at feltet er påkrevd, kan ikke være tomt. 
    [EmailAddress] // Validerer at e-posten er i et gyldig format. 
    public string? Email { get; set; }

    [Required] // Gjør at feltet er påkrevd, kan ikke være tomt. 
    [DataType(DataType.Password)] // Indikerer at dette feltet er et passord. 
    public string? Password { get; set; }

    [DataType(DataType.Password)] // Indikerer at dette feltet er et passordfelt. 
    [Display(Name = "Bekreft Passord")] // Tilpasser visningsteksten på skjemaet. 
    [Compare("Password", ErrorMessage = "Passordet og bekreftelsespassordet stemmer ikke overens.")]
    // Denne attributten sammenligner det oppgitte bekreftelsespassordet med det opprinnelige passordet. 
    public string? ConfirmPassword { get; set; }
}
