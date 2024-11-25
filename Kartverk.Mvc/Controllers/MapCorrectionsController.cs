using Kartverk.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kartverk.Mvc.Controllers
{
  // Controller for håndtering av forespørsler relatert til kartkorreksjoner.
  public class MapCorrectionsController : Controller
    {
        // GET: MapCorrections/Index
        // Viser et skjema for kartkorreksjon.
        public IActionResult Index()
        {
            var model = new MapCorrectionModel();
            return View(model);
        }

        // POST: MapCorrections/Save
        // Håndterer innsendelsen av kartkorreksjonsskjeamet.
        [HttpPost]
        public IActionResult Save(MapCorrectionModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            // Eksempel på data som håndteres.
            Console.WriteLine($"Kategori: {model.Category}, Beskrivelse: {model.Description}");

            return View("Success");
        }
    }
}


