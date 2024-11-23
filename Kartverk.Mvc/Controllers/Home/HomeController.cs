using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models;
using System.Text.Json;
using Kartverk.Mvc.Services;
using Microsoft.AspNetCore.Identity;

namespace Kartverk.Mvc.Controllers.Home;

// Controller som håndterer logikken for hjemmesiden.
public class HomeController : Controller
{
   // Logger som kan brukes til å logge informasjon og feilmeldinger.
   private readonly ILogger<HomeController> logger;

   // Konstruktør for HomeController. Loggeren initialiseres her. 
   public HomeController(ILogger<HomeController> logger)
    {
        this.logger = logger; // Loggeren blir tilgjengelig i hele controlleren.
    }
   
   // Denne metoden håndterer GET-forespørsler til 'Home/Index' og returnerer visningen.
    public IActionResult Index()
    {
        return View();
    }
    
    // Denne metoden håndterer POST-forespørsler når data sendes fra skjemaet på hjemmesiden.
    [HttpPost]
    public IActionResult Index(HomeViewModel model)
    {

       // Sjekker om modellen er valid (f.eks. om alle påkrevde felt er fylt ut korrekt).
       if (!ModelState.IsValid)
            return View("Index", model); // Hvis modellen er ugyldig, sendes den tilbake til visningen med feil. 

       // Hvis det finnes skjulte data, deserialiserer vi dem fra JSON.
       if (model.Hidden != null)
        {
            // Deserialiserer JSON-strengen til MapData-objektet.
            var mapData = JsonSerializer.Deserialize<MapData>(model.Hidden, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
       
       // Oppdaterer modellen med den nye meldingen som er sendt fra brukeren.
        model.Message = model.NewMessage;
        model.NewMessage = null; // Nullstiller NewMessage for å forhindre at den sendes tilbake i neste forespørsel. 
        
        // Returnerer visningen 'Index' med den oppdaterte modellen.
        return View("Index", model);
    }
    
    // Denne metoden håndterer GET-forespørsler til 'Home/Privacy' og viser personvern-siden.
    public IActionResult Privacy()
    {
        return View(); // Returnerer visningen for personvern. 
    }

    // Error handling metode for feilmeldinger, som viser en feilmelding når en feil skjer.
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] // Hindrer at feilsiden blir cached.
    public IActionResult Error()
    {
        // Henter sporings-ID (ReguestId) for feilen fra Activity eller HTTP-konteksten og sender det til feilsiden.
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // GET: Home/AdminLogin
    [HttpGet]
    public IActionResult AdminLogin()
    {
        return View();
    }

    // POST: Home/AdminLogin
    [HttpPost]
    public IActionResult AdminLogin(string adminPassword)
    {
        const string predefinedPassword = "admin123"; // Predefinert passord for admin
        if (adminPassword == predefinedPassword)
        {
            // Hvis passordet er riktig, omdiriger til admin-siden
            return RedirectToAction("Index", "AdminFeilmelding");
        }

        // Hvis passordet er feil, vis feilmelding
        ModelState.AddModelError("", "Feil admin-passord.");
        return View();
    }

    // GET: Home/AdminDashboard
    public IActionResult AdminDashboard()
    {
        return View(); // Dette er admin-siden
    }

}

// Modell som representerer kartdata (f.eks. punkter og linjer på kartet)
// public class MapData. 
public class MapData
{
    public List<LatLng> Points { get; set; } // Liste av punkter (hver punkt er et LatLng-objekt).
    public List<List<LatLng>> Lines { get; set; } // Liste av linjer (hver linje er en liste av punkter).
}

// Modell som representerer geografiske koordinater (breddegrad og lengdegrad)
public class LatLng
{
    public double Lat { get; set; } // Breddegrad (latitude)
    public double Lng { get; set; } // Lengdegrad (longitude)
}