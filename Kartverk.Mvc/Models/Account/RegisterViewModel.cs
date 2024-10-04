using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Bekreft Passord")]
    [Compare("Password", ErrorMessage = "Passordet og bekreftelsespassordet stemmer ikke overens.")]
    public string? ConfirmPassword { get; set; }
}
