using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Kartverk.Mvc.Models
{
    public class MapCorrectionModel
    {
        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public IFormFile? Attachment { get; set; }

        [Required]
        public string X { get; set; } = string.Empty;

        [Required]
        public string Y { get; set; } = string.Empty;
    }
}
