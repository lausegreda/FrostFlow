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
    public class ClienteController(IConfiguration _configuration) : ControllerBase
    {
        [Route("RegistrarCliente")]
        [HttpPost]
        public IActionResult RegistrarCliente(Cliente entidad)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                ClienteRespuesta respuesta = new ClienteRespuesta();

                var result = db.Execute("RegistrarCliente",
                    new { entidad.nombre, entidad.identificacion, entidad.direccion, entidad.telefono },
                    commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    respuesta.Codigo = "-1";
                    respuesta.Mensaje = "El Cliente ya se encuentra registrado";
                }
                return Ok(respuesta);


            }
        }

        [Route("ListadoClientes")]
        [HttpGet]
        public IActionResult ListadoClientes()
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                ClienteRespuesta respuesta = new ClienteRespuesta();

                var result = db.Query<Cliente>("ListadoClientes",
                    new { },
                    commandType: CommandType.StoredProcedure).ToList();

                if (result == null)
                {
                    respuesta.Codigo = "-1";
                    respuesta.Mensaje = "No hay clientes existentes.";
                }
                else
                {
                    respuesta.Datos = result;
                }

                return Ok(respuesta);
            }
        }

        [Route("EliminarCliente")]
        [HttpPut]
        public IActionResult EliminarCliente(Cliente entidad)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                ClienteRespuesta respuesta = new ClienteRespuesta();

                var result = db.Query<Cliente>("EliminarCliente",
                    new { entidad.id_cliente },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (result == null)
                {
                    respuesta.Codigo = "-1";
                    respuesta.Mensaje = "No se ha podido eliminar el cliente.";
                }
                else
                {
                    respuesta.Mensaje = "Cliente eliminado";
                }

                return Ok(respuesta);
            }
        }

        [Route("ModificarCliente")]
        [HttpPut]
        public IActionResult ModificarCliente(Cliente entidad)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                ClienteRespuesta respuesta = new ClienteRespuesta();

                var result = db.Execute("ModificarCliente",
                    new { entidad.id_cliente, entidad.nombre, entidad.identificacion, entidad.direccion, entidad.telefono },
                    commandType: CommandType.StoredProcedure);

                if (result <= 0)
                {
                    respuesta.Codigo = "-1";
                    respuesta.Mensaje = "No se pudo actualizar el cliente";
                }
                return Ok(respuesta);
            }
        }

        //EN CASO DE QUE SEAN NECESARIOS

        [Route("ConsultarCliente")]
        [HttpGet]
        public IActionResult ConsultarCliente(long id_cliente)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                ClienteRespuesta respuesta = new ClienteRespuesta();

                var result = db.Query<Cliente>("ConsultarCliente",
                    new { id_cliente },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (result == null)
                {
                    respuesta.Codigo = "-1";
                    respuesta.Mensaje = "El cliente no se encuentra registrado.";
                }
                else
                {
                    respuesta.Dato = result;
                }

                return Ok(respuesta);
            }
        }

        [Route("BuscarCliente")]
        [HttpGet]
        public IActionResult BuscarCliente(string identificacion)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                ClienteRespuesta respuesta = new ClienteRespuesta();

                var result = db.Query<Cliente>("BuscarCliente",
                    new { identificacion },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (result == null)
                {
                    respuesta.Codigo = "-1";
                    respuesta.Mensaje = "No existe el cliente con esa identificación.";
                }
                else
                {
                    respuesta.Dato = result;
                }

                return Ok(respuesta);
            }
        }

    }
}
