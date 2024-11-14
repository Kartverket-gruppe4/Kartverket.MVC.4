namespace Kartverk.Mvc.Models;

public class ErrorViewModel
{
    // Property for å lagre ID-en for forespørselen som førte til feilen. 
    public string? RequestId { get; set; }

    // Beregnet property som returnerer true hvis RequestId er ikke null eller tom.
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
