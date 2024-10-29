namespace Kartverk.Mvc.Models.Feilmelding
{
    public class GeoChange
    {
        public int Id { get; set; }
        public string? GeoJson { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public DateTime Dato { get; set; } = DateTime.Now;
        public string Kategori { get; set; }
    }
}