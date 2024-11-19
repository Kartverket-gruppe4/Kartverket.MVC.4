using Microsoft.AspNetCore.Mvc; // Importerer MVC-biblioteket for å håndtere HTTP-forespørsler og -svar
using Kartverk.Mvc.Models.Feilmelding; // Importerer modellen for feilmeldinger
using Microsoft.AspNetCore.Identity;

// Brukes til å håndtere feilmeldinger i administrasjonsdelen av applikasjonen
namespace Kartverk.Mvc.Controllers.AdminFeilmelding
{
    // Controller for administrasjon av feilmeldinger
    public class AdminFeilmeldingController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Konstruktør som tar inn ApplicationDbContext for å få tilgang til databasen
        public AdminFeilmeldingController(ApplicationDbContext context)
        {
            _context = context; // Initialiserer databasen som controlleren skal bruke
        }
        
        // Denne metoden håndterer GET-forespørsler til 'AdminFeilmelding/Index' og henter ut feilmeldinger fra databasen
        public IActionResult Index()
        {
            // Henter alle feilmeldinger fra databasen og konverterer til en liste
            var feilmeldinger = _context.feilmeldinger.ToList();

            // Sender listen med feilmeldinger til viewen for visning på websiden
            return View(feilmeldinger);
        }
        
        // Denne metoden håndterer POST-forespørsler og brukes til å oppdatere status på en feilmelding
        [HttpPost]
        public IActionResult EndreStatus(int id, string status)
        {
            // Henter feilmeldingen fra databasen basert på det spesifikke ID-et
            var feilmelding = _context.feilmeldinger.FirstOrDefault(f => f.Id == id);

            // Hvis feilmeldingen finnes
            if (feilmelding != null)
            {
                // Oppdaterer statusen på feilmeldingen
                feilmelding.Status = status; 

                // Lagre endringene til databasen
                _context.SaveChanges();
            }

            // Etter oppdateringen, omdirigerer vi tilbake til Index-siden for å vise de oppdaterte feilmeldingene
            return RedirectToAction("Index");
        }
    }
}
