using Microsoft.AspNetCore.Identity;

namespace Kartverk.Mvc.Models
{
    // Modell som representerer en bruker i applikasjonen.
    // Arver fra IdentityUser.
    public class ApplicationUser : IdentityUser
    {
        // Skjuler arvet UserName og deklarerer ny.
        public new string? UserName { get; set; }

        // Skjuler arvet Email og deklarerer ny.
        public new string? Email { get; set; }

        // Eget passordfelt, ikke en del av IdentityUser.
        public string? Password { get; set; }
    }
}
