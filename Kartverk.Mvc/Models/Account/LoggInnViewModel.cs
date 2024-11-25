using System.ComponentModel.DataAnnotations;

// Modell for de nødvendige feltene for innlogging.
public class LogginnViewModel
{
    // E-postfelt som er påkrevd for innlogging.
    [Required(ErrorMessage = "E-post er påkrevd.")]
    public string? Email { get; set; }

    // Passordfelt som er påkrevd for innlogging.
    [Required(ErrorMessage = "Passord er påkrevd.")]
    [DataType(DataType.Password)] 
    public string? Password { get; set; }
}
