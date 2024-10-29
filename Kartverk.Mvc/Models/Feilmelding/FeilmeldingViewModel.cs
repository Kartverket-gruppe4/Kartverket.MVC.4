using System.ComponentModel.DataAnnotations.Schema;

namespace Kartverk.Mvc.Models.Feilmelding
{
    [Table("feilmeldinger")] // Explicitly specifying lowercase name
    public class FeilmeldingViewModel
    {
        public int Id { get; set; }  // This corresponds to the primary key column "Id" in the database
        public string X { get; set; }  // Matches "X" in the database
        public string Y { get; set; }  // Matches "Y" in the database
        public string Email { get; set; }  // Matches "Email" in the database
        public string Beskrivelse { get; set; }  // Matches "Beskrivelse" in the database
        public string Kategori { get; set; }  // Matches "Kategori" in the database
        public DateTime Dato { get; set; }  // Matches "Dato" in the database
        public string GeoJson { get; set; }  // Matches "GeoJson" in the database
    }
}