namespace Kartverk.Mvc.Models
{
    public class Feilmelding
    {
        public int Id { get; set; } // Unik ID for feilmeldingen
        public string Epost { get; set; } // Brukerens e-post
        public string Beskrivelse { get; set; } // Beskrivelse av feilen
        public DateTime Dato { get; set; } = DateTime.Now; // Når meldingen ble sendt
    }
}