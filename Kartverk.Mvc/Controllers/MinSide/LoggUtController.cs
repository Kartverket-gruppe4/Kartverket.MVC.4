using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kartverk.Mvc.Controllers.MinSide;

// Controller for håndtering av utlogging av bruker.
public class LoggUtController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;

    // Konstruktør som sikrer at SignInManager blir injisert via DI
    public LoggUtController(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager)); // Sørger for at signInManager ikke er null
    }

    // POST: Account/Logout
    // Håndterer utlogging av bruker og omdirigerer til innlogginssiden.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Loggut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Logginn", "Account");
    }
}