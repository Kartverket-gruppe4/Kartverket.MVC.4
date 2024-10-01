using Microsoft.AspNetCore.Mvc;

namespace Kartverk.Mvc.Controllers
{
    public class FeilmeldingController : Controller // Riktig: 'Controller' (med stor C)
    {
        // GET: Feilmelding
        public IActionResult Index()
        {
            return View(); // Returnerer visningen for Feilmelding
        }
    }
}