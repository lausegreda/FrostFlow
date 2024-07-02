using FrostFlow.Entities;
using FrostFlow.Models;
using FrostFlow.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FrostFlow.Controllers
{
    public class ClienteController(IClienteModel _clienteModel) : Controller
    {
        [HttpGet]
        public IActionResult RegistrarCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarCliente(Cliente entidad)
        {
            var resp = _clienteModel.RegistrarCliente(entidad);

            if (resp?.Codigo == "00")
            {
                return RedirectToAction("ListadoClientes", "Cliente");
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View();
            }
        }

        [HttpGet]
        public IActionResult ListadoClientes()
        {
            var resp = _clienteModel.ListadoClientes();

            if (resp?.Codigo == "00")
                return View(resp?.Datos);
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View(new List<Cliente>());
            }
        }

        [HttpPost]
        public IActionResult EliminarCliente(Cliente entidad)
        {
            var resp = _clienteModel.EliminarCliente(entidad.id_cliente);

            if (resp?.Codigo == "00")
            {
                return RedirectToAction("ListadoClientes", "Cliente");
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return BadRequest(ViewBag.MsjPantalla);
            }
        }

        [HttpGet]
        public IActionResult ModificarCliente(long id_cliente)
        {
            var resp = _clienteModel.ConsultarCliente(id_cliente);
            return View(resp.Dato);
        }


        [HttpPost]
        public IActionResult ModificarCliente(Cliente entidad)
        {
            var resp = _clienteModel.ModificarCliente(entidad);

            if (resp?.Codigo == "00")
                return RedirectToAction("ListadoClientes", "Cliente");
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View();
            }
        }
    }
}
