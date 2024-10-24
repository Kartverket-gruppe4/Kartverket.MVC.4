using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models.Feilmelding;
using System.Collections.Generic;
using Kartverk.Mvc.Controllers.FeilMelding;

namespace Kartverk.Mvc.Controllers.AdminFeilmelding
{
    public class AdminFeilmeldingController : Controller
    {
        // GET: AdminFeilmelding/Index
        public IActionResult Index()
        {
            // Hent alle feilmeldinger fra tjenesten eller databasen
            var feilmeldinger = FeilmeldingController._feilmeldinger;

            // Send listen av feilmeldinger til visningen
            return View(feilmeldinger);
        }
    }
}
