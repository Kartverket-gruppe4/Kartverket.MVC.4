using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models.Feilmelding; 

namespace Kartverk.Mvc.Controllers.AdminFeilmelding
{
    // Controller for administrasjon av feilmeldinger.
    public class AdminFeilmeldingController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Konstruktør for å initialisere databasen.
        public AdminFeilmeldingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminFeilmelding/Index
        // Henter og viser alle feilmeldinger.
        public IActionResult Index()
        {
            var feilmeldinger = _context.feilmeldinger.ToList();
            return View(feilmeldinger);
        }

        // POST: AdminFeilmelding/EndreStatus
        // Oppdaterer status for en feilmelding.
        [HttpPost]
        public IActionResult EndreStatus(int id, string status)
        {
            var feilmelding = _context.feilmeldinger.FirstOrDefault(f => f.Id == id);

            if (feilmelding != null)
            {
                feilmelding.Status = status;
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Status oppdatert.";
            }
            else
            {
                TempData["ErrorMessage"] = "Feilmelding ikke funnet.";
            }

            return RedirectToAction("Index");
        }
    }
}
