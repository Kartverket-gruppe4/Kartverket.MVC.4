using System.ComponentModel.DataAnnotations;

public class LogginnViewModel
{
    [Required(ErrorMessage = "E-post er påkrevd.")]
    [RegularExpression(@"^[a-zA-Z0-9@._\-]+$", ErrorMessage = "Ugyldig e-postadresse.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Passord er påkrevd.")]
    [DataType(DataType.Password)]  
    [RegularExpression(@"^[a-zA-Z0-9._\-]+$", ErrorMessage = "Feil e-post eller passord.")]
    public string? Password { get; set; }
}
