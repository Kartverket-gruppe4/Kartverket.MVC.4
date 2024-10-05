using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models; // Husk å inkludere modellen din
using System.Collections.Generic;

namespace Kartverk.Mvc.Controllers
{
    public class FeilmeldingController : Controller
    {
        // Statisk liste for lagring av feilmeldinger
        private static List<Feilmelding> _feilmeldinger = new List<Feilmelding>();

        // GET: Feilmelding
        public IActionResult Index()
        {
            return View(); // Returnerer visningen for Feilmelding
        }

        // POST: Feilmelding/Opprett
        [HttpPost]
        public IActionResult Save(Feilmelding model)
        {
            if (ModelState.IsValid) // Sjekker om modellen er gyldig
            {
                // Legger til feilmeldingen i listen
                model.Id = _feilmeldinger.Count + 1; // Generer en unik ID
                _feilmeldinger.Add(model);

                // Omstyring til oversikten over innmeldinger (kan endres til ønsket side)
                return RedirectToAction("Oversikt");
            }
            return View(model); // Returnerer til viewet med eventuelle valideringsfeil
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
            return View("Oversikt", "Feilmelding");
        }
    }
}