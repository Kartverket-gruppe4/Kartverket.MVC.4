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
        }

        // Return the view with validation messages if login fails
        return View(model);
    }
}
