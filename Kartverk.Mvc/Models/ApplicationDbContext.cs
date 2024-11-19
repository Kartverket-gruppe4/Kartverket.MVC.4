using Microsoft.EntityFrameworkCore;

namespace Kartverk.Mvc.Models.Feilmelding
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Feilmeldinger lagring
        public DbSet<FeilmeldingViewModel> feilmeldinger { get; set; }

        // Brukerlagring
        public DbSet<IdentityUser> brukere { get; set; }
    }
}