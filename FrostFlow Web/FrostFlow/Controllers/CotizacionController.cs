using Microsoft.AspNetCore.Mvc;

namespace FrostFlow.Controllers
{
    public class CotizacionController : Controller
    {
        [HttpGet]
        public IActionResult RegistrarCotizacion()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MantenimientoCotizacion()
        {
            return View();
        
        }
    }
}
