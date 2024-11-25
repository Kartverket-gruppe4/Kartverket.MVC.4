using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required(ErrorMessage = "E-post er påkrevd.")]
    [EmailAddress(ErrorMessage = "E-postadressen er ugyldig.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", 
        ErrorMessage = "E-postadressen er ugyldig.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Passord er påkrevd.")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Passordet må være minst 6 tegn.")]
    [RegularExpression(@"^[a-zA-Z0-9._\-]+$", ErrorMessage = "Passordet inneholder ugyldige tegn.")]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Bekreft Passord")]
    [Compare("Password", ErrorMessage = "Passordene stemmer ikke overens.")]
    public string? ConfirmPassword { get; set; }
}