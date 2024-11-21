using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models.Feilmelding;
using Microsoft.AspNetCore.Identity;
using Kartverk.Mvc.Models;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // GET: Account/LoggInn
    public ActionResult LoggInn()
    {
        return View();
    }

    // For post request handling of login
    [HttpPost]
    public async Task<IActionResult> LoggInn(LogginnViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    userName: user.Email,
                    password: model.Password,
                    isPersistent: false,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    HttpContext.Response.Cookies.Append("UserEmail", user.Email, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        Expires = DateTimeOffset.Now.AddDays(30)
                    });

                    return RedirectToAction("Index", "MinSide", new { email = user.Email });
                }
            }

            ModelState.AddModelError("", "Invalid login attempt.");
        }

        // Returnerer view med valideringsfeil
        return View(model);
    }

    // POST: Account/LoggUt
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LoggUt()
    {
        await _signInManager.SignOutAsync();

        // Clear cookies if needed (e.g., the custom UserEmail cookie)
        if (HttpContext.Request.Cookies.ContainsKey("UserEmail"))
        {
            HttpContext.Response.Cookies.Delete("UserEmail");
        }

        return RedirectToAction("Index", "Home");
    }

    // GET: Account/Register
    public ActionResult Register()
    {
        return View();
    }

    // POST: Account/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Brukeren eksisterer allerede.");
                return View(model);
            }

            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("LoggInn");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        // returnerer til registreringssiden hvis det er valideringsfeil
        return View(model);
    }

    // Hente bruker etter e-postadresse
    public IdentityUser? GetUserByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }


}
