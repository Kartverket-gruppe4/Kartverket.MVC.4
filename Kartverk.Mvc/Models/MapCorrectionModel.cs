using System.ComponentModel.DataAnnotations;

namespace Kartverk.Mvc.Models
{
    public class MapCorrectionModel
    {
        // Kategori for kartkorreksjonen.
        [Required]
        public string Category { get; set; } = string.Empty;

        // Beskrivelse av problemet. 
        [Required]
        public string Description { get; set; } = string.Empty;

       // Eventuelt vedlegg som kan lastes opp. 
       public IFormFile? Attachment { get; set; }

        // GeoJSON-data som beskriver geogafisk plassering eller område. 
        [Required]
        public string GeoJson { get; set; } = string.Empty;
        
        // Info om kommunen som kartkorreksjonen gjelder for. 
        public string KommuneInfo { get; set; } = string.Empty;
    }
}
