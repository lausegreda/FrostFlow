using Dapper;
using FrostFlow_API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace FrostFlow_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IConfiguration _configuration) : ControllerBase
    {

        [Route("IniciarSesion")]
        [HttpPost]
        public IActionResult IniciarSesion(Usuario entidad)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                UsuarioRespuesta respuesta = new UsuarioRespuesta();

                var result = db.Query<Usuario>("IniciarSesion",
                    new { entidad.correo, entidad.contrasenna },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (result == null)
                {
                    respuesta.Codigo = "0";
                    respuesta.Mensaje = "Sus datos no son correctos, intente nuevamente.";
                }
                else
                {
                    respuesta.Dato = result;
                }

                return Ok(respuesta);
            }
        }

        [Route("RegistrarTecnico")]
        [HttpPost]
        public IActionResult RegistrarTecnico(Usuario entidad)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                UsuarioRespuesta respuesta = new UsuarioRespuesta();

                var result = db.Execute("RegistrarTecnico",
                    new { entidad.nombre, entidad.correo, entidad.contrasenna },
                    commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    respuesta.Codigo = "0";
                    respuesta.Mensaje = "El técnico ya se encuentra registrado.";
                }

                return Ok(respuesta);
            }
        }

        [Route("ConsultarTecnicos")]
        [HttpGet]
        public IActionResult ConsultarTecnicos()
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                UsuarioRespuesta respuesta = new UsuarioRespuesta();

                var result = db.Query<Usuario>("ConsultarTecnicos",
                    new { },
                    commandType: CommandType.StoredProcedure).ToList();

                if (result == null)
                {
                    respuesta.Codigo = "0";
                    respuesta.Mensaje = "No hay Técnicos registrados";
                }
                else
                {
                    respuesta.Datos = result;
                }

                return Ok(respuesta);
            }
        }

        [Route("EliminarTecnico")]
        [HttpDelete]
        public IActionResult EliminarTecnico(int id_Usuario)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                UsuarioRespuesta respuesta = new UsuarioRespuesta();

                var result = db.Execute("EliminarTecnico",
                    new { id_Usuario },
                    commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    respuesta.Codigo = "0";
                    respuesta.Mensaje = "No se pudo eliminar el Técnico, intente nuevamente.";
                }

                return Ok(respuesta);
            }
        }

        [Route("ConsultarTecnico")]
        [HttpGet]
        public IActionResult ConsultarTecnico(int id_Usuario)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                UsuarioRespuesta respuesta = new UsuarioRespuesta();

                var result = db.Query<Usuario>("ConsultarTecnico",
                    new { id_Usuario },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (result == null)
                {
                    respuesta.Codigo = "0";
                    respuesta.Mensaje = "Técnico no registrado";
                }
                else
                {
                    respuesta.Dato = result;
                }

                return Ok(respuesta);
            }
        }


        [Route("ActualizarTecnico")]
        [HttpPut]
        public IActionResult ActualizarTecnico(Usuario entidad)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                UsuarioRespuesta respuesta = new UsuarioRespuesta();

                var result = db.Execute("ActualizarTecnico",
                    new { entidad.id_Usuario, entidad.nombre, entidad.correo, entidad.contrasenna },
                    commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    respuesta.Codigo = "0";
                    respuesta.Mensaje = "No se pudo actualizar el Técnico, intente nuevamente";
                }

                return Ok(respuesta);
            }
        }
    }
}
