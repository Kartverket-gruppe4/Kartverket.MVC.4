using Microsoft.AspNetCore.Mvc;


namespace Kartverk.Mvc.Controllers
{
    // InnboksController håndterer logikken for å vise brukerens innboks.
    public class InnboksController : Controller
    {
        // Denne metoden håndterer en GET-forespørsel til 'Innboks/Index'.
        public IActionResult Index()
        {
            // Her kan du hente data fra en database eller annen kilde for å vise brukerens innboks
            return View(); // Returnerer visningen som viser innboksdata til brukeren. 
        }
    }
}