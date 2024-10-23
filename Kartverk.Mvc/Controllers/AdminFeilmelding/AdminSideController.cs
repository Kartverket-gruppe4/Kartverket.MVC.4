using Microsoft.AspNetCore.Mvc;

namespace Kartverk.Mvc.Controllers.AdminFeilmelding
{
    public class AdminFeilmeldingController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Pek på "Index" visningen i Views/AdminFeilmelding
        }
    }
}