﻿using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Storage;

public class AccountController : Controller
{
    // simulert lagring
    public static List<IdentityUser> Users = new List<IdentityUser>();

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
            var user = Users.FirstOrDefault(u => u.Email == model.Email);
            if (user != null && user.Password == model.Password)
            {
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
            if (Users.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError(string.Empty, "Brukeren eksisterer allerede.");
                return View(model);
            }

            // Oppretter ny bruker og legger den til
            var user = new IdentityUser { UserName = model.Email, Email = model.Email, Password = model.Password };
            Users.Add(user);

            // brukeren omdirigeres dersom det lykkes
            return RedirectToAction("LoggInn");
        }
        // returnerer til registreringssiden hvis det er valideringsfeil
        return View(model);
    }

    // Hente bruker etter e-postadresse
    public static IdentityUser? GetUserByEmail(string email)
    {
        return Users.FirstOrDefault(u => u.Email == email);
    }


}
