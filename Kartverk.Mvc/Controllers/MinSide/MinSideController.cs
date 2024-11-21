using Kartverk.Mvc.Models.MinSide;
using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models.Feilmelding;
using Kartverk.Mvc.Models;
using Microsoft.AspNetCore.Identity;

namespace Kartverk.Mvc.Controllers.MinSide;

public class MinSideController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public MinSideController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> Index(string email)
    {
        var userEmail = HttpContext.Request.Cookies["UserEmail"];

        if (!string.IsNullOrEmpty(userEmail))
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user != null)
            {
                var model = new MinSideViewModel
                {
                    Email = user.Email
                };

                return View(model);
            }
        }

        // If no valid cookie, redirect to login
        return RedirectToAction("LoggInn", "Account");
    }

    // GET: MinSide/MineInnmeldinger
    [HttpGet]
    public IActionResult MineInnmeldinger()
    {
        // Her kan vi hente innmeldinger fra databasen, for n� er det tomt
        return RedirectToAction("Oversikt", "Feilmelding");
    }
}
