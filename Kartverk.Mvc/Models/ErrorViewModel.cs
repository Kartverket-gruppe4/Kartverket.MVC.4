namespace Kartverk.Mvc.Models;

// Modell for å håndtere feilmeldinger og vise informasjon om forespørselen som feilet.
public class ErrorViewModel
{
    // ID-en for forespørselen som førte til feilen.
    public string? RequestId { get; set; }

    // Returnerer true hvis RequestId ikke er null eller tom.
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
