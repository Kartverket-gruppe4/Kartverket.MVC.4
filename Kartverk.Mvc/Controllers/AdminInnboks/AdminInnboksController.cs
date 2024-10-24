using Microsoft.AspNetCore.Mvc;

namespace Kartverk.Mvc.Controllers.AdminInnboks
{
    public class AdminInnboksController : Controller
    {
        // GET: Admin Innboks
        public IActionResult Index()
        {
            return View();
        }
    }
}