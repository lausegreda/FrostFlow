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
            //HttpContext.Session.Clear(); //Cierra la sesi�n en caso de que se acceda manualmente a la vista
            return View();
        }

        [Seguridad]
        [HttpGet]
        public IActionResult PantallaTecnico()
        {
            //HttpContext.Session.Clear();
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
                HttpContext.Session.SetString("Nombre", resp.Dato.nombre);
                HttpContext.Session.SetString("Correo", resp.Dato.correo);
                HttpContext.Session.SetString("IdRol", resp.Dato.id_Rol.ToString());
                HttpContext.Session.SetString("NombreRol", resp.Dato.nombreRol.ToString());
                HttpContext.Session.SetString("Login", "true");

                if (resp.Dato.id_Rol == 1)
                {
                    HttpContext.Session.SetString("Login", "true");
                    return RedirectToAction("PantallaPrincipal", "Home");
                }
                else
                {
                    HttpContext.Session.SetString("Login", "true");
                    return RedirectToAction("PantallaTecnico", "Home");
                }
                
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
        public IActionResult PasswordFormulario()
        {
            //HttpContext.Session.Clear();
            return View();
        }

        [HttpGet]
        public IActionResult Calendario()
        {
            return View();
        }
    }
}
