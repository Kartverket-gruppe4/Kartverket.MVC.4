using Kartverk.Mvc.Models.MinSide;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace Kartverk.Mvc.Controllers.MinSide;

// Controller for MinSide som håndterer brukerens side og relaterte funksjoner
public class MinSideController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public MinSideController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // GET: MinSide/Index
    // Viser brukerens MinSide basert på e-post fra cookie.
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

                return View(model); // Returnerer visning med brukerinformasjon.
            }
        }
        return RedirectToAction("LoggInn", "Account");
    }

    // GET: MinSide/MineInnmeldinger
    // Omdirigerer til oversikt over brukerens feilmeldinger.
    [HttpGet]
    public IActionResult MineInnmeldinger()
    {
        return RedirectToAction("Oversikt", "Feilmelding");
    }
}
