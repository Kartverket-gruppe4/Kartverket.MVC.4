using Microsoft.AspNetCore.Mvc;

namespace Kartverk.Mvc.Controllers.AdminInnboks
{
    //controller for administrasjon av innboksen
    public class AdminInnboksController : Controller
    {
        // Denne metoden håndterer GEt-forespørsler til AdminInnboks/Index.
        // Den henter og viser oversikten av innboksen til administratoren. 
        public IActionResult Index()
        {
           // Returnerer en View som viser innboksen
           return View();
        }
    }
}