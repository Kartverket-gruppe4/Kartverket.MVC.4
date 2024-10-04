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
                Email = user.Epost
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
    public IActionResult AdminLogin(string adminPassord)
    {
        const string predefinedPassword = "admin123"; // Predefinert passord for admin
        if (adminPassord == predefinedPassword)
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
        // Her kan vi hente innmeldinger fra databasen, for n� er det tomt
        return View();
    }
}
