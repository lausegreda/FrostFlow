using Microsoft.AspNetCore.Mvc;

namespace FrostFlow.Controllers
{
    public class ReportesController : Controller
    {
        public IActionResult ConsultarReportes()
        {
            return View();
        }
    }
}
