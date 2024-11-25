using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models.Feilmelding;
using Microsoft.AspNetCore.Identity;

// Controller for brukerhåndtering.
public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    // Konstruktør for å initialiser database og identitetshåndtering.
    public AccountController(
        ApplicationDbContext context,
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // GET: Account/LoggInn
    // Viser innlogginssiden.
    public ActionResult LoggInn()
    {
        return View();
    }

    // POST: Account/LoggInn
    // Håndterer innlogginsforespørsel.
    [HttpPost]
    public async Task<IActionResult> LoggInn(LogginnViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email!);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    userName: user.Email!,
                    password: model.Password!,
                    isPersistent: false,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    // Setter cookie for brukers e-post.
                    HttpContext.Response.Cookies.Append("UserEmail", user.Email!, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        Expires = DateTimeOffset.Now.AddDays(30)
                    });

                    // Sjekker om brukeren er administrator og omdirigerer deretter.
                    if (await _userManager.IsInRoleAsync(user, "Administrator"))
                    {
                        return RedirectToAction("Index", "AdminFeilmelding");
                    }

                    return RedirectToAction("Index", "MinSide", new { email = user.Email });
                }
            }
            // Feilmelding for ugyldig innlogging.
            ModelState.AddModelError("", "Invalid login attempt.");
        }
        return View(model);
    }

    // POST: Account/LoggUt
    // Logger ut brukeren og sletter eventuelle cookies.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LoggUt()
    {
        await _signInManager.SignOutAsync();

        // Clear cookies if needed (e.g., the custom UserEmail cookie).
        if (HttpContext.Request.Cookies.ContainsKey("UserEmail"))
        {
            HttpContext.Response.Cookies.Delete("UserEmail");
        }

        return RedirectToAction("Index", "Home");
    }

    // GET: Account/Register
    // Viser registreringssiden.
    public ActionResult Register()
    {
        return View();
    }

    // POST: Account/Register
    // Håndterer registreringsforespørsel.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email!);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Brukeren eksisterer allerede.");
                return View(model);
            }

            // Validerer e-postformat.
            if (model.Email!.Contains("@"))
            {
                ModelState.AddModelError("Email", "E-postadressen er ikke gyldig.");
                return View(model);
            }

            // Validerer passordlengde.
            if (model.Password!.Length < 6)
            {
                ModelState.AddModelError("Password", "Passordet må være minst 6 tegn.");
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

            // Legger til feil fra opprettelsesprosessen.
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }

    // GET: Account/GetUserByEmail
    // Hente bruker etter e-postadresse.
    public IdentityUser? GetUserByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }

}
