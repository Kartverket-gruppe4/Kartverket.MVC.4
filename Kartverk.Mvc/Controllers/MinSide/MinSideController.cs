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

    // GET: MinSide/AdminLogin
    [HttpGet]
    public IActionResult AdminLogin()
    {
        return View();
    }

    // POST: MinSide/AdminLogin
    [HttpPost]
    public IActionResult AdminLogin(string adminPassword)
    {
        const string predefinedPassword = "admin123"; // Predefinert passord for admin
        if (adminPassword == predefinedPassword)
        {
            // Hvis passordet er riktig, omdiriger til admin-siden
            return RedirectToAction("AdminDashboard");
        }

        // Hvis passordet er feil, vis feilmelding
        ModelState.AddModelError("", "Feil admin-passord.");
        return View();
    }

    // GET: MinSide/AdminDashboard
    public IActionResult AdminDashboard()
    {
        return View(); // Dette blir admin-siden
    }
}
