using Microsoft.AspNetCore.Mvc;

namespace FrostFlow.Controllers
{
    public class PlanillaController : Controller
    {
        public IActionResult RegistrarEmpleado()
        {
            return View();
        }

        public IActionResult MantenimientoEmpleado()
        {
            return View();
        }

        public IActionResult GenerarPlanilla()
        {
            return View();
        }
    }
}
