using Microsoft.AspNetCore.Mvc;

namespace FrostFlow.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult ConsultarCliente()
        {
            return View();
        }

        public IActionResult RegistrarCliente()
        {
            return View();
        }
    }
}
