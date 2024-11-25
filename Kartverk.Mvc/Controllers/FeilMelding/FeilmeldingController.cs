using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models;
using Kartverk.Mvc.Models.Feilmelding;
using Kartverk.Mvc.Services;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization; 

namespace Kartverk.Mvc.Controllers.FeilMelding
{
    // Kontroller for håndtering av feilmeldinger.
    public class FeilmeldingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IKommuneInfoService _kommuneInfoService;
        private readonly ILogger<FeilmeldingController> _logger;
        private readonly FeilmeldingService _feilmeldingService;
        private readonly UserManager<IdentityUser> _userManager;

        // Konstruktør for initialisering.
        public FeilmeldingController(
            ApplicationDbContext context,
            IKommuneInfoService kommuneInfoService,
            ILogger<FeilmeldingController> logger,
            FeilmeldingService feilmeldingService,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _kommuneInfoService = kommuneInfoService;
            _logger = logger;
            _feilmeldingService = feilmeldingService;
            _userManager = userManager;
        }

        // GET: Feilmelding/Index
        // Viser hovedsiden for feilmeldinger.
        public IActionResult Index()
        {
            return View();
        }

        // POST: Feilmelding/Opprett
        // Oppretter en ny feilmelding.
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Save(MapCorrectionModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var feilmelding = new FeilmeldingViewModel
                    {
                        GeoJson = model.GeoJson,
                        KommuneInfo = model.KommuneInfo,
                        Email = user.Email, 
                        UserId = user.Id,
                        Beskrivelse = model.Description,
                        Kategori = model.Category,
                        Status = "Ny"
                    };

                    _context.feilmeldinger.Add(feilmelding);
                    await _context.SaveChangesAsync();

                    return View("Confirmation");
                }
                ModelState.AddModelError("", "User not found.");
                return View("Index", model);
            }
            else
            {
                return View("Index", model);
            }
        }

        // GET: Feilmelding/Oversikt
        // Viser oversikt over brukerens feilmeldinger.
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Oversikt()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                ModelState.AddModelError("", "Bruker ikke funnet.");
                return RedirectToAction("Logginn", "Account");
            }

            var userId = user.Id;
            var feilmeldinger = _feilmeldingService.GetAllFeilmeldinger(userId);

            foreach (var feilmelding in feilmeldinger)
            {
                if (feilmelding.GeoJson != null)
                {
                    feilmelding.GeoJson = JsonConvert.SerializeObject(feilmelding.GeoJson);
                }
            }
            return View(feilmeldinger);
        }

        // GET: Feilmelding/Edit
        // Oppdaterer oversikten over feilmeldinger og returnerer riktig view.
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UpdateOverview(string viewName = "Oversikt")
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    ModelState.AddModelError("", "Bruker ikke funnet.");
                    return RedirectToAction("Logginn", "Account");
                }

                var userId = user.Id;

                var feilmeldinger = _feilmeldingService.GetAllFeilmeldinger(userId);
                if (viewName == "Index")
                {
                    return View("~/Views/AdminFeilmelding/Index.cshtml", feilmeldinger);
                }
                return View("~/Views/Feilmelding/Oversikt.cshtml", feilmeldinger);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Feil ved henting av feilmeldinger.");
                return View("Error");
            }
        }

        // GET: Feilmelding/Edit
        // Henter en feilmelding for redigering.
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            _logger.LogInformation($"Edit GET action called with id={id}");

            var user = await _userManager.GetUserAsync(User);

            if (user == null) 
            {
                return RedirectToAction("Logginn", "Account");
            }

            var userId = user.Id;

            var feilmeldinger = _feilmeldingService.GetFeilmeldingById(id, userId);
            if (feilmeldinger == null)
            {
                _logger.LogWarning($"Feilmelding med id={id} ikke funnet for brukerId={userId}");
                return NotFound();
            }
            return View(feilmeldinger);
        }

        // POST: Feilmelding/Edit
        // Oppdaterer en feilmelding.
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(FeilmeldingViewModel model)
        {
            ModelState.Remove("UserId");

            var user = await _userManager.GetUserAsync(User);

            if (user == null) 
            {
                return RedirectToAction("Logginn", "Account");
            }

            model.UserId = user.Id;

            if (ModelState.IsValid)
            {
                _logger.LogInformation("Modelstate is valid. Updating feilmelding.");

                _feilmeldingService.UpdateFeilmelding(
                    model.Email!,
                    model.Beskrivelse!,
                    DateTime.Now.ToString("yyyy-MM-dd"),
                    model.GeoJson,
                    model.KommuneInfo,
                    model.Status!,
                    user.Id);

                return RedirectToAction("UpdateOverview");
            }
            else
            {
                _logger.LogWarning("Modelstate is invalid.");
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _logger.LogWarning(error.ErrorMessage);
                    }
                }
            }
            return View(model);
        }

        // GET: Feilmelding/Delete
        // Viser detaljene til en feilmelding for bekreftelse av sletting.
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Logginn", "Account");
            }

            var userId = user.Id;

            var feilmeldinger = _feilmeldingService.GetFeilmeldingById(id, userId);
            if (feilmeldinger == null)
            {
                return NotFound();
            }
            return View(feilmeldinger);
        }

        // POST: Feilmelding/Delete
        // Sletter en feilmelding.
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, string viewName)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Logginn", "Account");
            }

            var userId = user.Id;

            try
            {
                _feilmeldingService.DeleteFeilmelding(id, userId);
                TempData["SuccessMessage"] = "Feilmeldingen ble slettet.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Noe gikk galt ved sletting: {ex.Message}";
            }

            if (string.IsNullOrEmpty(viewName) || viewName == "Index")
            {
                return RedirectToAction("Index", "AdminFeilmelding");
            }
            else if (viewName == "Oversikt")
            {
                return RedirectToAction("Oversikt", "Feilmelding");
            }
            else
            {
                return RedirectToAction("Index", "AdminFeilmelding");
            }
        }

        // GET: Feilmelding/MineInnmeldinger
        // Viser alle feilmeldinger registrert av innlogget bruker.
        public async Task<IActionResult> MineInnmeldinger()
        {
            var email = HttpContext.Request.Cookies["UserEmail"];

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Oversikt", "Feilmelding");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return RedirectToAction("Oversikt", "Feilmelding");
            }

            var userId = user.Id;

            var brukerFeilmeldinger = _context.feilmeldinger
                .Where(f => f.Email == email)
                .ToList();
            return View("Oversikt", brukerFeilmeldinger);
        }

        // GET: api/Feilmelding/Kommuneinfo
        // Henter kommuneinformasjon basert på koordinater.
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
