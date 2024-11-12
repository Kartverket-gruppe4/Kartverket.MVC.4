using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models.Feilmelding;
using System.Collections.Generic;
using Kartverk.Mvc.Controllers.FeilMelding;

namespace Kartverk.Mvc.Controllers.AdminFeilmelding
{
    public class AdminFeilmeldingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminFeilmeldingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminFeilmelding/Index
        public IActionResult Index()
        {
            // Hent alle feilmeldinger fra databasen
            var feilmeldinger = _context.feilmeldinger.ToList();

            // Send listen av feilmeldinger til visningen
            return View(feilmeldinger);
        }
        
        // Post-metode for å endre status på en feilmelding
        [HttpPost]
        public IActionResult EndreStatus(int id, string status)
        {
            // Henter feilmeldingen med det spesifikke ID-et fra databasen
            var feilmelding = _context.feilmeldinger.FirstOrDefault(f => f.Id == id);

            if (feilmelding != null)
            {
                feilmelding.Status = status; // Oppdaterer statusen 

                // lagre endringene i databasen
                _context.SaveChanges();
            }

            // Omstyring tilbake til oversikten/Index etter at status er oppdatert
            return RedirectToAction("Index");
        }
    }
}
