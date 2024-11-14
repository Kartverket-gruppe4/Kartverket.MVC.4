namespace Kartverk.Mvc.Models.MinSide;

public class MinSideViewModel
{
    // Antall feilmeldinger brukeren har sendt.
    public int AntallInnmeldinger { get; set; }
   
    // Brukerens e-post.
    public string? Email { get; set; }
}