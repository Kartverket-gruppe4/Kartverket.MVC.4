using System.ComponentModel.DataAnnotations.Schema;

namespace Kartverk.Mvc.Models.Feilmelding
{
    // Attributtet Table spesifiserer hvilket navn tabellen skal ha i databasen.
    [Table("feilmeldinger")] 
    public class FeilmeldingViewModel
    {
        // Unik identifikator for feilmeldingen i databasen (primærnøkkel).
        public int Id { get; set; } 
        
        // Brukerens e-postadresse (kan være null).
        public string? Email { get; set; } 
        
        // Beskrivelse av feilmeldingen (kan være null).
        public string? Beskrivelse { get; set; } 
        
        // Når feilmeldingen ble sendt (standardverdi er dagens dato).
        public DateTime Dato { get; set; } = DateTime.Now; 
        
        // Geometrisk data i GeoJSON-format (kan ikke være null).
        public string GeoJson { get; set; }
        
        // Kategori som feilmeldingen tilhører (kan ikke være null).
        public string Kategori { get; set; }

        // Kommuneinfo relatert til feilmeldingen, kan være null.
        [Column("KommuneInfo")] // Spesifiserer kolonnenavnet i databasen.
        public string KommuneInfo { get; set; }
        
        // Status på feilmeldingen, kan være null.
        public string? Status { get; set; }
    }
}