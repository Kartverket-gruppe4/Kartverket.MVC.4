using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Kartverk.Mvc.Models
{
    public class MapCorrectionModel
    {
        [Required]
        public string Category { get; set; } = string.Empty; // Initialiser med tom streng

        [Required]
        public string Description { get; set; } = string.Empty; // Initialiser med tom streng

        [Required]
        public string X { get; set; } = string.Empty; // Initialiser med tom streng

        [Required]
        public string Y { get; set; } = string.Empty; // Initialiser med tom streng

        public IFormFile? Attachment { get; set; } // Gjør Attachment nullable
    }
}
