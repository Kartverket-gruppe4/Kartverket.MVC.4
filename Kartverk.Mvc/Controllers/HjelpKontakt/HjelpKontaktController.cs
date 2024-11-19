using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models.HjelpKontakt;
namespace Kartverk.Mvc.Controllers.HjelpKontakt
{
   // Controller for hjelp og kontakt-siden.
   public class HjelpKontaktController : Controller
    {
       // Denne metoden håndterer GET-forespørsler til 'HjelpKontakt/Index' og viser hjelp og kontakt-siden. 
       public IActionResult Index()
        {
            //// Returnerer visningen (View) som kan vise informasjon relatert til hjelp og kontakt.
            return View();
        }

    }
}