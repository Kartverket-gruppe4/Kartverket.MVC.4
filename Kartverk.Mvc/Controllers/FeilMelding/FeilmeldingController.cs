using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models;
using Kartverk.Mvc.Models.Feilmelding;
using Kartverk.Mvc.Services;
using Newtonsoft.Json; // Import for IKommuneInfoService

namespace Kartverk.Mvc.Controllers.FeilMelding
{
    public class FeilmeldingController : Controller
    {
        private readonly IKommuneInfoService _kommuneInfoService;

        // Statisk liste for lagring av feilmeldinger
        public static List<FeilmeldingViewModel> _feilmeldinger = new List<FeilmeldingViewModel>();

        // Constructor med dependency injection for IKommuneInfoService
        public FeilmeldingController(IKommuneInfoService kommuneInfoService)
        {
            _kommuneInfoService = kommuneInfoService;
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
                FeilmeldingViewModel feilmelding = new FeilmeldingViewModel
                {
                    Id = _feilmeldinger.Count + 1,
                    GeoJson = model.GeoJson,
                    KommuneInfo = model.KommuneInfo,
                    Email = AccountController.Users.First().Email,
                    Beskrivelse = model.Description,
                    Kategori = model.Category
                };

                _feilmeldinger.Add(feilmelding);

                // Returnerer til Confirmation-siden
                return View("Confirmation");
            }

            // Returnerer til hovedsiden med modellen hvis det er valideringsfeil
            return View("Index", model);
        }


        // GET: Feilmelding/Oversikt
        public IActionResult Oversikt()
        {
            return View(_feilmeldinger); // Sender listen med feilmeldinger til viewet
        }

        // GET: Feilmelding/MineInnmeldinger
        public IActionResult MineInnmeldinger()
        {
            // bruker samme liste som i oversikt
            return View("Oversikt", _feilmeldinger);
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
