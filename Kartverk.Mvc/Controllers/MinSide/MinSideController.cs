using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models.MinSide;

namespace Kartverk.Mvc.Controllers.MinSide;

public class MinSideController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Index(string Email)
    {
        // Bruk emailen til å hente brukerdata (eller bare vise emailen)
        var user = AccountController.GetUserByEmail(Email);

        if (user != null)
        {
            // Opprett ViewModel for MinSide og sett epost
            var model = new MinSideViewModel
            {
                Email = user.Email
            };

            // Send modellen til View
            return View(model);
        }

        // Hvis brukeren ikke finnes, returner til LoggInn
        return RedirectToAction("LoggInn", "Account");
    }
}