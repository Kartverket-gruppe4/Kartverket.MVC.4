using System.ComponentModel.DataAnnotations;

// Modell for de nødvendige feltene for innlogging.
public class LogginnViewModel
{
    // E-postfelt som er påkrevd for innlogging.
    [Required(ErrorMessage = "E-post er påkrevd.")]
    [RegularExpression(@"^[a-zA-Z0-9@._\-]+$", ErrorMessage = "Ugyldig e-postadresse.")]
    public string? Email { get; set; }

    // Passordfelt som er påkrevd for innlogging.
    [Required(ErrorMessage = "Passord er påkrevd.")]
    [DataType(DataType.Password)]  
    [RegularExpression(@"^[a-zA-Z0-9._\-]+$", ErrorMessage = "Feil e-post eller passord.")]
    public string? Password { get; set; }
}
