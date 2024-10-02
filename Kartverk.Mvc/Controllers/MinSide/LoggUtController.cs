using Microsoft.AspNetCore.Mvc;

namespace Kartverk.Mvc.Controllers.MinSide;

public class LoggUtController : Controller
{
    // GET
    public IActionResult LoggUt()
    {
        return RedirectToAction("Index", "Home");
    }
}