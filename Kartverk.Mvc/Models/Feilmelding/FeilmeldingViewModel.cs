using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Kartverk.Mvc.Models.Feilmelding
{
    // Angir tabellnavnet i databasen.
    [Table("feilmeldinger")] 
    public class FeilmeldingViewModel
    {
        // Primærnøkkel for feilmeldingen.
        [Key]
        public int Id { get; set; }

        // Brukerens e-postadresse.
        [Required]
        public string Email { get; set; } = string.Empty;

        // Beskrivelse av feilmeldingen.
        [Required]
        public string? Beskrivelse { get; set; } 
        
        // Dato feilmeldingen ble sendt.
        public DateTime Dato { get; set; } = DateTime.Now;

        // Geometrisk data (GeoJSON-format).
        [Required]
        public string GeoJson { get; set; } = string.Empty;
        
        // Kategori for feilmeldingen.
        public string Kategori { get; set; } = string.Empty;

        // Kommuneinfo relatert til feilmeldingen.
        [Column("KommuneInfo")]
        public string KommuneInfo { get; set; } = string.Empty;
        
        // Status på feilmeldingen.
        public string? Status { get; set; }

        // Forhindrer binding av UserId for brukerens input.
        [BindNever]
        public string UserId {  get; set; } = string.Empty;
    }
}