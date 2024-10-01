using Microsoft.AspNetCore.Mvc;

namespace Kartverk.Mvc.Controllers
{
    public class FeilmeldingController : Controller
    {
        // GET: Feilmelding
        public IActionResult Index()
        {
            return View(); // Returnerer visningen for Feilmelding
        }
    }   
}