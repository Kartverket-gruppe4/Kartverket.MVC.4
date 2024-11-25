using Microsoft.AspNetCore.Mvc;

namespace Kartverk.Mvc.Controllers.HjelpKontakt
{
   // Controller for håndtering av hjelp og kontakt-siden.
   public class HjelpKontaktController : Controller
    {
       // GET: HjelpKontakt/Index
       // Viser hjelp og kontakt-siden.
       public IActionResult Index()
        {
            return View();
        }

    }
}