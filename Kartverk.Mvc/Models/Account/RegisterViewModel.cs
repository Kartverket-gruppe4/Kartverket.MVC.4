using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string? Epost { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Passord { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Bekreft Passord")]
    [Compare("Passord", ErrorMessage = "Passordet og bekreftelsespassordet stemmer ikke overens.")]
    public string? BekreftPassord { get; set; }
}
