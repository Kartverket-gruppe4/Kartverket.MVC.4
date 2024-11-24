using System.ComponentModel.DataAnnotations;

public class LogginnViewModel
{
    [Required(ErrorMessage = "E-post er påkrevd.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Passord er påkrevd.")]
    [DataType(DataType.Password)] // Indikerer at dette feltet er et passord. 
    public string? Password { get; set; }
}
