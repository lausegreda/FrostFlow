using Microsoft.AspNetCore.Mvc;

namespace FrostFlow.Controllers
{
    public class OrdenTrabajoController : Controller
    {
        [HttpGet]
        public IActionResult OrdenesTrabajo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Notificaciones()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AsignacionTecnico()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TecnicoOT()
        {
            return View();
        }
    }
}
