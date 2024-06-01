using Microsoft.AspNetCore.Mvc;

namespace FrostFlow.Controllers
{
    public class FacturaController : Controller
    {
        [HttpGet]
        public IActionResult RegistrarFactura()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MantenimientoFactura()
        {
            return View();

        }
    }
}
