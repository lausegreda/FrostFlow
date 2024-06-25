using FrostFlow.Entities;
using FrostFlow.Interfaces;
using FrostFlow.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrostFlow.Controllers
{
    [Seguridad]
    [ResponseCache(NoStore = true, Duration = 0)]
    public class TecnicosController(IUsuarioModel _usuarioModel, IUtilitariosModel _utilitariosModel) : Controller
    {
        [HttpGet]
        public IActionResult TecnicoRegistro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TecnicoRegistro(Usuario entidad)
        {

            entidad.contrasenna= _utilitariosModel.Encrypt(entidad.contrasenna);
            var resp = _usuarioModel.RegistrarTecnico(entidad);

            if (resp.Codigo == "1")
                return RedirectToAction("TecnicoListado", "Tecnicos");
            else
            {
                ViewBag.MsjPantalla = resp.Mensaje;
                return View();
            }
        }

        [HttpGet]
        public IActionResult TecnicoListado()
        {
            var resp = _usuarioModel.ConsultarTecnicos();

            if (resp.Codigo == "1")
                return View(resp.Datos);
            else
            {
                ViewBag.MsjPantalla = resp.Mensaje;
                return View(new List<Usuario>());
            }
        }

        [HttpGet]
        public IActionResult EditarTecnico()
        { 
            return View(); 
        
        }

        [HttpPost]
        public IActionResult EliminarTecnico(Usuario entidad)
        {
            var resp = _usuarioModel.EliminarTecnico(entidad.id_Usuario);

            if (resp.Codigo == "1")
                return RedirectToAction("TecnicoListado", "Tecnicos");
            else
            {
                ViewBag.MsjPantalla = resp.Mensaje;
                return View();
            }
        }


        [HttpGet]
        public IActionResult ActualizarTecnico(int id)
        {
            var resp = _usuarioModel.ConsultarTecnico(id);
            return View(resp.Dato);
        }


        [HttpPost]
        public IActionResult ActualizarTecnico(Usuario entidad)
        {
            var resp = _usuarioModel.ActualizarTecnico(entidad);

            if (resp.Codigo == "1")
                return RedirectToAction("TecnicoListado", "Tecnicos");
            else
            {
                ViewBag.MsjPantalla = resp.Mensaje;
                return View();
            }
        }


    }
}
