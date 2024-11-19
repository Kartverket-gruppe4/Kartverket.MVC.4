using Kartverk.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kartverk.Mvc.Controllers
{
  // MapCorrectionsController håndterer forespørsler relatert til kartkorreksjoner.
  public class MapCorrectionsController : Controller
    {
        // Denne metoden håndterer en GET-forespørsel til 'MapCorrections/Index'.
        public IActionResult Index()
        {
            // Initialiser en ny MapCorrectionModel (som representerer et skjema for kartkorreksjon).
            var model = new MapCorrectionModel();
           
            // Returnerer visningen og sender modellen til visningen. Modellen inneholder data som kan vises i skjemaet. 
            return View(model);
        }

        // Denne metoden håndterer en POST-forespørsel når skjemaet sendes.
        [HttpPost]
        public IActionResult Save(MapCorrectionModel model)
        {
            // Hvis modellens data ikke er gyldige, returnerer skjemaet sammen med feilmeldinger. 
            if (!ModelState.IsValid)
            {
                // Returnerer til 'Index' med modellen (som inneholder feilmeldinger).
                return View("Index", model);
            }

            // Hvis valideringen er vellykket, kan vi håndtere de innsendte dataene.
            // Eksempel: Logge data for testing, eller lagre til database.
            Console.WriteLine($"Kategori: {model.Category}, Beskrivelse: {model.Description}");

            // Etter suksessfull lagring, kan man returnere en bekreftelsesside eller lignende.
            return View("Success"); // Returnerer til 'Success' visningen for å bekrefte innsendelsen.
        }
    }
}


