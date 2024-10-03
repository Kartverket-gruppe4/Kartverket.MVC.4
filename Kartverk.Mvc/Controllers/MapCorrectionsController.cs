using Kartverk.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kartverk.Mvc.Controllers
{
    public class MapCorrectionsController : Controller
    {
        public IActionResult Index()
        {
            // Initialiser MapCorrectionModel og send den til visningen
            var model = new MapCorrectionModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Save(MapCorrectionModel model)
        {
            if (!ModelState.IsValid)
            {
                // Hvis valideringen feiler, returner skjemaet med feilmeldinger
                return View("Index", model);
            }

            // Logikk for å håndtere innsendte data
            // Eksempel: Logge data for testing, eller lagre til database
            Console.WriteLine($"Kategori: {model.Category}, Beskrivelse: {model.Description}, Koordinater: {model.X}, {model.Y}");

            // Etter suksessfull lagring, kan man returnere en bekreftelsesside eller lignende
            return View("Success");
        }
    }
}


