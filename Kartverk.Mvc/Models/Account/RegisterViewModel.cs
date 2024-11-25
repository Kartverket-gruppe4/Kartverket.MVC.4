using System.ComponentModel.DataAnnotations;

// Modell for registrering.
public class RegisterViewModel
{
    // E-postfelt som er påkrevd for registrering.
    [Required(ErrorMessage = "E-post er påkrevd.")]
    [EmailAddress(ErrorMessage = "E-postadressen er ugyldig.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", 
        ErrorMessage = "E-postadressen er ugyldig.")]
    public string? Email { get; set; }

    // Passordfelt som er påkrevd for registrering.
    [Required(ErrorMessage = "Passord er påkrevd.")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Passordet må være minst 6 tegn.")]
    [RegularExpression(@"^[a-zA-Z0-9._\-]+$", ErrorMessage = "Passordet inneholder ugyldige tegn.")]
    public string? Password { get; set; }

    // Bekreftelsespassord, for å sikre at brukeren har skrevet inn passordet korrekt.
    [DataType(DataType.Password)]
    [Display(Name = "Bekreft Passord")]
    [Compare("Password", ErrorMessage = "Passordene stemmer ikke overens.")]
    public string? ConfirmPassword { get; set; }
}