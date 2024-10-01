using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models.MinSide;

namespace Kartverk.Mvc.Controllers.MinSide;

public class MinSideController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Index(string Email)
    {
        var user = AccountController.GetUserByEmail(Email);

        if (user != null)
        {
            var model = new MinSideViewModel
            {
                Email = user.Email
            };
            
            return View(model);
        }
        
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

    // GET: MinSide/MineInnmeldinger
    [HttpGet]
    public IActionResult MineInnmeldinger()
    {
        // Her kan vi hente innmeldinger fra databasen, for nå er det tomt
        return View();
    }
}
