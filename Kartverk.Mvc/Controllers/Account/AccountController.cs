using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models.Feilmelding;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Account/LoggInn
    public ActionResult LoggInn()
    {
        return View();
    }

    // For post request handling of login
    [HttpPost]
    public IActionResult LoggInn(LogginnViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Handle login logic here, e.g., verify user credentials
            // Redirect to another page if successful
            var user = _context.brukere.FirstOrDefault(u => u.Email == model.Email);
            if (user != null && user.Password == model.Password)
            {
                HttpContext.Response.Cookies.Append("UserEmail", user.Email, new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddDays(1), // Set the expiration date as needed
                    IsEssential = true // Mark the cookie as essential (optional)
                });

                // redirect til ønsket side
                return RedirectToAction("Index", "MinSide", new { email = user.Email });
            }

            ModelState.AddModelError(string.Empty, "Ugyldig Innlogging.");
        }

        // Returnerer view med valideringsfeil
        return View(model);
    }

    // GET: Account/Register
    public ActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (_context.brukere.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError(string.Empty, "Brukeren eksisterer allerede.");
                return View(model);
            }

            // Oppretter ny bruker og legger den til
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                Password = model.Password
            };

            _context.brukere.Add(user);
            _context.SaveChanges();

            // brukeren omdirigeres dersom det lykkes
            return RedirectToAction("LoggInn");
        }
        // returnerer til registreringssiden hvis det er valideringsfeil
        return View(model);
    }

    // Hente bruker etter e-postadresse
    public IdentityUser? GetUserByEmail(string email)
    {
        return _context.brukere.FirstOrDefault(u => u.Email == email);
    }


}
