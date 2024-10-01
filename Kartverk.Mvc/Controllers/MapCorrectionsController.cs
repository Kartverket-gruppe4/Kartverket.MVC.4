using Kartverk.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kartverk.Mvc.Controllers
{
    public class MapCorrectionsController : Controller
    {
        public IActionResult Index()
        {
            // Oppretter en ny modell uten nødvendige verdier for Attachment
            return View(new MapCorrectionModel());
        }

        [HttpPost]
        public IActionResult Save(MapCorrectionModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            // Håndter lagring av data her, f.eks. lagre Attachment om det finnes

            return View("Index", model); // Returner modellen til visningen for bekreftelse
        }
    }
}

