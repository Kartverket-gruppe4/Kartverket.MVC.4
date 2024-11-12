using Microsoft.EntityFrameworkCore;

namespace Kartverk.Mvc.Models.Feilmelding
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // representerer en samling av objekter som kan knyttes til database-tabell
        public DbSet<FeilmeldingViewModel> feilmeldinger { get; set; }
    }
}