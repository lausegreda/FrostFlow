using FrostFlow.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FrostFlow.Controllers
{
    public class TecnicosController : Controller
    {
        public IActionResult TecnicoRegistro()
        {
            return View();
        }

        public IActionResult TecnicoListado()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TecnicoRegistro(Tecnico entidad)
        {
            return RedirectToAction("TecnicoListado", "Tecnicos");
        }
    }
}
