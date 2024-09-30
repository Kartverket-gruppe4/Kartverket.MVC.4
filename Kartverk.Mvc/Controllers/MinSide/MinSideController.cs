using Microsoft.AspNetCore.Mvc;

namespace Kartverk.Mvc.Controllers.MinSide;

public class MinSideController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}