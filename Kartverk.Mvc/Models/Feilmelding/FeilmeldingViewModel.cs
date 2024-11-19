using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Kartverk.Mvc.Models.Feilmelding
{
    // Attributtet Table spesifiserer hvilket navn tabellen skal ha i databasen.
    [Table("feilmeldinger")] 
    public class FeilmeldingViewModel
    {
        // Unik identifikator for feilmeldingen i databasen (primærnøkkel).
        [Key]
        public int Id { get; set; }

        // Brukerens e-postadresse
        [Required]
        public string? Email { get; set; }

        // Beskrivelse av feilmeldingen
        [Required]
        public string? Beskrivelse { get; set; } 
        
        // Når feilmeldingen ble sendt (standardverdi er dagens dato).
        public DateTime Dato { get; set; } = DateTime.Now;

        // Geometrisk data i GeoJSON-format (kan ikke være null).
        [Required]
        public string GeoJson { get; set; }
        
        // Kategori som feilmeldingen tilhører (kan ikke være null).
        public string Kategori { get; set; }

        // Kommuneinfo relatert til feilmeldingen, kan være null.
        [Column("KommuneInfo")] // Spesifiserer kolonnenavnet i databasen.
        public string KommuneInfo { get; set; }
        
        // Status på feilmeldingen, kan være null.
        public string? Status { get; set; }

        // UserId som blir forhindra til at den bindes automatisk fra brukerens input
        [BindNever]
        public string UserId {  get; set; }
    }
}