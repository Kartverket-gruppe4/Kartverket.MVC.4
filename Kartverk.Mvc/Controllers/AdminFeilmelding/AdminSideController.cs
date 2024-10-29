using Microsoft.AspNetCore.Mvc;
using Kartverk.Mvc.Models.Feilmelding;
using System.Collections.Generic;
using Kartverk.Mvc.Controllers.FeilMelding;

namespace Kartverk.Mvc.Controllers.AdminFeilmelding
{
    public class AdminFeilmeldingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminFeilmeldingController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: AdminFeilmelding/Index
        public IActionResult Index()
        {
            // Hent alle feilmeldinger fra databasen
            var feilmeldinger = _context.feilmeldinger.ToList();

            // Send listen av feilmeldinger til visningen
            return View(feilmeldinger);
        }
    }
}
