using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models;
using Kartverk.Mvc.Models.Feilmelding;
using Kartverk.Mvc.Services;
using Newtonsoft.Json; // Import for IKommuneInfoService.

namespace Kartverk.Mvc.Controllers.FeilMelding
{
    public class FeilmeldingController : Controller
    {
        // EF
        private readonly ApplicationDbContext _context;

        private readonly IKommuneInfoService _kommuneInfoService;

        private readonly ILogger<FeilmeldingController> _logger;

        public FeilmeldingController(ApplicationDbContext context, IKommuneInfoService kommuneInfoService, ILogger<FeilmeldingController> logger)
        {
            _context = context;
            _kommuneInfoService = kommuneInfoService;
            _logger = logger;
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
            if (ModelState.IsValid)
            {
                var user = HttpContext.Request.Cookies["UserEmail"];

                if (user != null)
                {
                    var feilmelding = new FeilmeldingViewModel
                    {
                        GeoJson = model.GeoJson,
                        KommuneInfo = model.KommuneInfo,
                        Email = user,
                        Beskrivelse = model.Description,
                        Kategori = model.Category,
                        Status = "Ny"
                    };

                    // lagre feilmeldingen i databasen
                    _context.feilmeldinger.Add(feilmelding);
                    _context.SaveChanges();

                    // Returnerer til Confirmation-siden
                    return View("Confirmation");
                }

                // Returnerer til hovedsiden med modellen hvis det er valideringsfeil
                return View("Index", model);
            }
            else
            {
                ModelState.AddModelError("", "User not found.");
                return View("Index", model);
            }
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
            var email = HttpContext.Request.Cookies["UserEmail"];

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Oversikt", "Feilmelding");
            }

            // finner brukers feilmeldinger fra databasen
            var brukerFeilmeldinger = _context.feilmeldinger
                .Where(f => f.Email == email)
                .ToList();
            return View("Oversikt", brukerFeilmeldinger);
        }

        // Ny GET-metode for å hente kommuneinfo basert på koordinater
        [HttpGet("api/feilmelding/kommuneinfo")]
        public async Task<IActionResult> GetKommuneInfo(double nord, double ost)
        {
            var kommuneInfo = await _kommuneInfoService.GetKommuneInfoAsync(nord, ost);
            if (kommuneInfo == null)
            {
                return NotFound("Ingen kommuneinformasjon funnet for de gitte koordinatene.");
            }
            return Ok(kommuneInfo);
        }
    }
}