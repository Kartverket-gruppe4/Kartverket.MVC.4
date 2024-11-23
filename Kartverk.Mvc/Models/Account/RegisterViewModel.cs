using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required(ErrorMessage = "E-post er påkrevd.")]
    [EmailAddress(ErrorMessage = "Ugyldig e-postadresse. Sørg for at den inneholder '@'.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Passord er påkrevd.")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Passordet må være minst 6 tegn.")]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Bekreft Passord")]
    [Compare("Password", ErrorMessage = "Passordet og bekreftelsespassordet stemmer ikke overens.")]
    public string? ConfirmPassword { get; set; }
}

