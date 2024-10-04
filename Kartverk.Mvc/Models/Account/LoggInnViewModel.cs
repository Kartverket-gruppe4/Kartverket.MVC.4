using System.ComponentModel.DataAnnotations;

public class LogginnViewModel
{
    [Required]
    [EmailAddress]
    public string? Epost { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Passord { get; set; }
}
