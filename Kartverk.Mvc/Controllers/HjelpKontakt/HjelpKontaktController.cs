using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models.HjelpKontakt;
namespace Kartverk.Mvc.Controllers.HjelpKontakt
{
    public class HjelpKontaktController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}