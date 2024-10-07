using Microsoft.AspNetCore.Mvc;

namespace Kartverk.Mvc.Controllers.Innboks
{
    public class InnboksController : Controller
    {
        // GET: Innboks
        public IActionResult Index()
        {
            return View();
        }
    }
}