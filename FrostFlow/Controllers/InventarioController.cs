using Microsoft.AspNetCore.Mvc;

namespace FrostFlow.Controllers
{
    public class InventarioController : Controller
    {
        [HttpGet]
        public IActionResult BuscadorProducto()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegistrarProducto()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Notificaciones()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Informes()
        {
            return View();
        }

    }
}
