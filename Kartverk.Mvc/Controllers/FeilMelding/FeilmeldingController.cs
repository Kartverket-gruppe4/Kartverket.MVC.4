using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models;
using Kartverk.Mvc.Models.Feilmelding;

namespace Kartverk.Mvc.Controllers.FeilMelding
{
    public class FeilmeldingController : Controller
    {
        // EF
        private readonly ApplicationDbContext _context;

        // Statisk liste for lagring av feilmeldinger
        // public static List<FeilmeldingViewModel> _feilmeldinger = new List<FeilmeldingViewModel>();

        public FeilmeldingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Feilmelding
        public IActionResult Index()
        {
            return View(); // Returnerer visningen for Feilmelding
        }


        // POST: Feilmelding/Opprett
        [HttpPost]
        public IActionResult Save(MapCorrectionModel model)
        {
            if (ModelState.IsValid) // Sjekker om modellen er gyldig
            {
                var feilmelding = new FeilmeldingViewModel
                {
                    X = model.X,
                    Y = model.Y,
                    Email = AccountController.Users.First().Email,
                    Beskrivelse = model.Description,  // Map Description -> Beskrivelse
                    Kategori = model.Category  // Map Category -> Kategori
                };

                // lagre feilmeldngen i databasen
                _context.feilmeldinger.Add(feilmelding);
                _context.SaveChanges();

                // Omstyring til oversikten over innmeldinger (kan endres til ønsket side)
                return RedirectToAction("Oversikt");
            }
            return View("Index", model); // Returnerer til viewet med eventuelle valideringsfeil
        }

        // GET: Feilmelding/Oversikt
        public IActionResult Oversikt()
        {
            var feilmeldinger = _context.feilmeldinger.ToList();
            return View(feilmeldinger);
        }

        // GET: Feilmelding/MineInnmeldinger
        public IActionResult MineInnmeldinger()
        {
            //Finner brukers feilmeldinger fra databasen
            var brukerFeilmeldinger = _context.feilmeldinger
                .Where(f => f.Email == AccountController.Users.First().Email)
                .ToList();
            return View("Oversikt", brukerFeilmeldinger);
        }
    }
}