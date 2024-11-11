using Microsoft.AspNetCore.Mvc;


namespace Kartverk.Mvc.Controllers
{
    public class InnboksController : Controller
    {
        // GET: Innboks
        public IActionResult Index()
        {
            // Her kan du hente data fra en database eller annen kilde for å vise brukerens innboks
            return View();
        }
    }
}