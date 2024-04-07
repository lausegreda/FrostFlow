using Microsoft.AspNetCore.Mvc;

namespace FrostFlow.Controllers
{
    public class CotizacionController : Controller
    {
        public IActionResult RegistrarCotizacion()
        {
            return View();
        }

        public IActionResult MantenimientoCotizacion()
        {
            return View();
        
        }
    }
}
