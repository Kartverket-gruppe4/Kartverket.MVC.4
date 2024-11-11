using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models.Feilmelding;
using System.Collections.Generic;
using Kartverk.Mvc.Controllers.FeilMelding;

namespace Kartverk.Mvc.Controllers.AdminFeilmelding
{
    public class AdminFeilmeldingController : Controller
    {
        // GET: AdminFeilmelding/Index
        public IActionResult Index()
        {
            // Hent alle feilmeldinger fra tjenesten eller databasen
            var feilmeldinger = FeilmeldingController._feilmeldinger;

            // Send listen av feilmeldinger til visningen
            return View(feilmeldinger);
        }
        
        // Post-metode for å endre status på en feilmelding
        [HttpPost]
        public IActionResult EndreStatus(int id, string status)
        {
            // Henter feilmeldingen med det spesifikke ID-et
            var feilmelding = FeilmeldingController._feilmeldinger.FirstOrDefault(f => f.Id == id);

            if (feilmelding != null)
            {
                feilmelding.Status = status; // Oppdaterer statusen til den valgte verdien
            }

            // Omstyring tilbake til oversikten/Index etter at status er oppdatert
            return RedirectToAction("Index");
        }
    }
}
