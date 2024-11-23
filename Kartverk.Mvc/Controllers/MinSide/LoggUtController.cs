using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kartverk.Mvc.Controllers.MinSide;

public class LoggUtController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;

    // POST: Account/Logout
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Loggut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Logginn", "Account");
    }
}