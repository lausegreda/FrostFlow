using FrostFlow.Entities;
using FrostFlow.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FrostFlow.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult PantallaPrincipal()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Calendario()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TecnicoRegistro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioEnt entidad)
        {
            return RedirectToAction("PantallaPrincipal", "Home");
        }

        [HttpPost]
        public IActionResult TecnicoRegistro(UsuarioEnt entidad)
        {
            return RedirectToAction("PantallaPrincipal", "Home");
        }
    }
}
