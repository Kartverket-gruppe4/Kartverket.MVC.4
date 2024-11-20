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
        if (string.IsNullOrEmpty(email))
        {
            return RedirectToAction("LoggInn", "Account");
        }

        var user = await _userManager.FindByEmailAsync(email);

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
    
}
