using System.ComponentModel.DataAnnotations;

public class LogginnViewModel
{
    [Required] // Gjør at feltet er påkrevd, kan ikke være tomt. 
    [EmailAddress] // Validerer at e-posten er i et gyldig format. 
    public string? Email { get; set; }

    [Required] // Gjør at feltet er påkrevd, kan ikke være tomt.
    [DataType(DataType.Password)] // Indikerer at dette feltet er et passord. 
    public string? Password { get; set; }
}
