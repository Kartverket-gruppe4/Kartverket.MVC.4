using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Kartverk.Mvc.Models;

namespace Kartverk.Mvc.Models.Feilmelding
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
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