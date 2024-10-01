using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models.MinSide;

namespace Kartverk.Mvc.Controllers.MinSide;

public class MinSideController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Index(string Email)
    {
        var user = AccountController.GetUserByEmail(Email);

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