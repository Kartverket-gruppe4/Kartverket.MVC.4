using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Kartverk.Mvc.Controllers.Home;

// Controller som håndterer logikken for hjemmesiden.
public class HomeController : Controller
{
   private readonly ILogger<HomeController> logger;

   // Konstruktør for initialisering av logger.
   public HomeController(ILogger<HomeController> logger)
    {
        this.logger = logger;
    }
   
   // GET: Home/Index
   // Returnerer visning til index.
    public IActionResult Index()
    {
        return View();
    }
    
    // POST: Home/Index
    // Håndterer skjema-innsending og oppdaterer modellen med data for brukeren.
    [HttpPost]
    public IActionResult Index(HomeViewModel model)
    {
       if (!ModelState.IsValid)
            return View("Index", model); // Returnerer visningen med feil hvis modellen er ugyldig.

       if (model.Hidden != null)
        {
            var mapData = JsonSerializer.Deserialize<MapData>(model.Hidden, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        model.Message = model.NewMessage;
        model.NewMessage = null; // Nullstiller NewMessage for å forhindre at den sendes tilbake i neste forespørsel. 
        
        return View("Index", model);
    }
    
    // GET: Home/Privacy
    // Viser personvern-siden.
    public IActionResult Privacy()
    {
        return View();
    }

    // GET: Home/Error
    // Viser feilside med sporings-ID.
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] // Hindrer at feilsiden blir cached.
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // GET: Home/AdminDashboard
    // Viser admin-siden hvis brukeren er en administrator.
    [Authorize(Roles = "Administrator")]
    public IActionResult AdminDashboard()
    {
        return View();
    }

}

// Modell som representerer kartdata.
public class MapData
{
    public List<LatLng> ?Points { get; set; }
    public List<List<LatLng>> ?Lines { get; set; }
}

// Modell som representerer geografiske koordinater.
public class LatLng
{
    public double Lat { get; set; } // Breddegrad (latitude)
    public double Lng { get; set; } // Lengdegrad (longitude)
}