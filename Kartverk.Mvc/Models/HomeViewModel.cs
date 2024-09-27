using Kartverk.Mvc.Controllers;
using Kartverk.Mvc.ModelValidators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class HomeViewModel
{
    public string? Message { get; set; }
    [Required]
    [DisplayName("Ny melding")]
    public string? NewMessage { get; set; }


    [PrimenumberValidator]
    [DisplayName("Primtall(kan være null)")]
    public int? Number { get; set; }

    
    public string? Hidden { get; set; }
}
