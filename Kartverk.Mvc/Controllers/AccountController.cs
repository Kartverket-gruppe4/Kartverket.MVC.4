using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    // GET: Account/LoggInn
    public ActionResult LoggInn()
    {
        return View();
    }

    // For post request handling of login
    [HttpPost]
    public ActionResult LoggInn(LogginnViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Handle login logic here, e.g., verify user credentials
            // Redirect to another page if successful
            return new RedirectResult("/MinSide");
        }

        // Return the view with validation messages if login fails
        return View(model);
    }

    // GET: Account/Register
    public ActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Her kan vi implementere logikk for å registrere brukeren, 
            // som å lagre brukeren i databasen

            // Hvis registreringen var vellykket, kan brukeren omdirigeres
            return RedirectToAction("LoggInn");
        }

        // Returner til registreringssiden hvis det er valideringsfeil
        return View(model);
    }

}
