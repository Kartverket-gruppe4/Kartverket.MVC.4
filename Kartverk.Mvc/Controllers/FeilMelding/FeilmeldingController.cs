using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models;
using Kartverk.Mvc.Models.Feilmelding;
using Kartverk.Mvc.Services;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization; // Import for IKommuneInfoService.

namespace Kartverk.Mvc.Controllers.FeilMelding
{
    public class FeilmeldingController : Controller
    {
        // EF
        private readonly ApplicationDbContext _context;

        private readonly IKommuneInfoService _kommuneInfoService;
        private readonly ILogger<FeilmeldingController> _logger;

        private readonly FeilmeldingService _feilmeldingService;
        private readonly UserManager<IdentityUser> _userManager;

        public FeilmeldingController(ApplicationDbContext context, IKommuneInfoService kommuneInfoService, ILogger<FeilmeldingController> logger, FeilmeldingService feilmeldingService, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _kommuneInfoService = kommuneInfoService;
            _logger = logger;
            _feilmeldingService = feilmeldingService;
            _userManager = userManager;
        }

        // GET: Feilmelding
        public IActionResult Index()
        {
            return View(); // Returnerer visningen for Feilmelding
        }

        // POST: Feilmelding/Opprett
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Save(MapCorrectionModel model)
        {
            if (ModelState.IsValid)
            {
                // Get the current logged-in user
                var user = await _userManager.GetUserAsync(User);

                if (user != null)
                {
                    var feilmelding = new FeilmeldingViewModel
                    {
                        GeoJson = model.GeoJson,
                        KommuneInfo = model.KommuneInfo,
                        Email = user.Email, // Get the user's email from Identity
                        UserId = user.Id,
                        Beskrivelse = model.Description,
                        Kategori = model.Category,
                        Status = "Ny"
                    };

                    // Add the feilmelding to the database
                    _context.feilmeldinger.Add(feilmelding);
                    await _context.SaveChangesAsync();

                    // Return Confirmation view
                    return View("Confirmation");
                }

                // If no user is found, handle accordingly
                ModelState.AddModelError("", "User not found.");
                return View("Index", model);
            }
            else
            {
                // Handle model validation failure
                return View("Index", model);
            }
        }


        // GET: Feilmelding/Oversikt
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
            return View(feilmeldinger);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UpdateOverview()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var userId = user.Id;

                var allChanges = _feilmeldingService.GetAllFeilmeldinger(userId);
                return View(allChanges);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Feil ved henting av feilmeldinger.");
                return View("Error");
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            _logger.LogInformation($"Edit GET action called with id={id}");

            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            var feilmeldinger = _feilmeldingService.GetFeilmeldingById(id, userId);
            if (feilmeldinger == null)
            {
                _logger.LogWarning($"Feilmelding med id={id} ikke funnet for brukerId={userId}");
                return NotFound();
            }
            return View(feilmeldinger);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(FeilmeldingViewModel model)
        {
            ModelState.Remove("UserId");

            var user = await _userManager.GetUserAsync(User);

            model.UserId = user.Id;

            if (ModelState.IsValid)
            {
                _logger.LogInformation("Modelstate is valid. Updating feilmelding.");

                _feilmeldingService.UpdateFeilmelding(model.Email, model.Beskrivelse, DateTime.Now.ToString("yyyy-MM-dd"), model.GeoJson, model.KommuneInfo, model.Status, user.Id);
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            var feilmeldinger = _feilmeldingService.GetFeilmeldingById(id, userId);
            if (feilmeldinger == null)
            {
                return NotFound();
            }
            return View(feilmeldinger);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            _feilmeldingService.DeleteFeilmelding(id, userId);
            return RedirectToAction("UpdateOverview");
        }

        // GET: Feilmelding/MineInnmeldinger
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
