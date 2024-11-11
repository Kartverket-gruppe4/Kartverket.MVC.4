namespace Kartverk.Mvc.Models.Feilmelding
{
    public class FeilmeldingViewModel
    {
        public int Id { get; set; } // Unik ID for feilmeldingen
        public string? Email { get; set; } // Brukerens e-post
        public string? Beskrivelse { get; set; } // Beskrivelse av feilen
        public DateTime Dato { get; set; } = DateTime.Now; // Når meldingen ble sendt
        public string X { get; set; }
        public string Y { get; set; }
        public string GeoJson {  get; set; }
        public string Kategori { get; set; }
        public string KommuneInfo { get; set; }
        
        public string Status { get; set; }
    }
}