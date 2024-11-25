using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// Modell for integrering av databasen
namespace Kartverk.Mvc.Models.Feilmelding
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        // Konstruktør for å initialisere database
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Feilmeldinger lagring
        public DbSet<FeilmeldingViewModel> feilmeldinger { get; set; }
    }
}