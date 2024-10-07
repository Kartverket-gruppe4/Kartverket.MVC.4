using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models;
using System.Text.Json;

namespace Kartverk.Mvc.Controllers.Home;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> logger;

    public HomeController(ILogger<HomeController> logger)
    {
        this.logger = logger;
    }

    public IActionResult Index()
    {
        var model = new HomeViewModel();
        model.Message = "Det tar en time";

        return View("Index", model);
    }

    [HttpPost]
    public IActionResult Index(HomeViewModel model)
    {

        if (!ModelState.IsValid)
            return View("Index", model);

        if (model.Hidden != null)
        {
            var mapData = JsonSerializer.Deserialize<MapData>(model.Hidden, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        model.Message = model.NewMessage;
        model.NewMessage = null;
        return View("Index", model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
public class MapData
{
    public List<LatLng> Points { get; set; }
    public List<List<LatLng>> Lines { get; set; }
}

public class LatLng
{
    public double Lat { get; set; }
    public double Lng { get; set; }
}