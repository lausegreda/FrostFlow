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

        [Route("Prueba")]
        [HttpPost]
        public IActionResult IniciarSesion(Usuario entidad)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                var result = db.Query<Usuario>("Prueba",
                    new { entidad.nombreUsuario, entidad.contrasenna },
                    commandType: CommandType.StoredProcedure).ToList();

                return Ok(result);
            }
        }
    }
}
