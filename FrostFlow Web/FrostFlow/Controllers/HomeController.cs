using FrostFlow.Entities;
using FrostFlow.Interfaces;
using FrostFlow.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FrostFlow.Controllers
{
    [ResponseCache(NoStore = true, Duration = 0)] // Validaci�n realizada para evitar que mediante la navegaci�n entre p�ginas no se aplique el filtro personalizado
    public class HomeController(IUsuarioModel _usuarioModel) : Controller //Inyecci�n de dependencia
    {

        [Seguridad] // Se le aplica filtro personalizado para que no se pueda acceder a esta vista a menos que se tenga una sesi�n activa. (Ruta: Models/Seguridad)
        [HttpGet]
        public IActionResult PantallaPrincipal()
        {
            HttpContext.Session.Clear(); //Cierra la sesi�n en caso de que se acceda manualmente a la vista
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario entidad)
        {
            var resp = _usuarioModel.IniciarSesion(entidad);

            if (resp.Codigo == "1")
            {
                HttpContext.Session.SetString("Login", "true");
                return RedirectToAction("PantallaPrincipal", "Home");
            }
            else
            {
                ViewBag.MsjPantalla = resp.Mensaje;
                return View();
            }
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
        public IActionResult TecnicoRegistro(Usuario entidad)
        {
            return RedirectToAction("PantallaPrincipal", "Home");
        }
    }
}
