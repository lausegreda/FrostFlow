using FrostFlow.Entities;
using FrostFlow.Interfaces;
using FrostFlow.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FrostFlow.Controllers
{
    [ResponseCache(NoStore = true, Duration = 0)] // Validación realizada para evitar que mediante la navegación entre páginas no se aplique el filtro personalizado
    public class HomeController(IUsuarioModel _usuarioModel) : Controller //Inyección de dependencia
    {

        [Seguridad] // Se le aplica filtro personalizado para que no se pueda acceder a esta vista a menos que se tenga una sesión activa. (Ruta: Models/Seguridad)
        [HttpGet]
        public IActionResult PantallaPrincipal()
        {
            return View();
        }
        public IActionResult PantallaTecnico()
        {
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
                HttpContext.Session.SetString("NombreUsuario", resp?.Dato?.nombreUsuario!);
                HttpContext.Session.SetString("IdRol", resp?.Dato?.id_Rol.ToString()!);
                HttpContext.Session.SetString("NombreRol", resp?.Dato?.nombreRol.ToString()!);
                HttpContext.Session.SetString("Login", "true");

                if (resp?.Dato?.nombreRol == "Administrador")
                {
                    return RedirectToAction("PantallaPrincipal", "Home");
                }
                return RedirectToAction("PantallaTecnico", "Home");
            }

            else
            {
                ViewBag.MsjPantalla = resp.Mensaje;
                return View();
            }
        }

        [HttpGet]
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
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
