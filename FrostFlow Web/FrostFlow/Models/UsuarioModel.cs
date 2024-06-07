using FrostFlow.Entities;
using FrostFlow.Interfaces;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;

namespace FrostFlow.Models
{
    public class UsuarioModel(HttpClient _http,
                                IConfiguration _configuration,
                                IHttpContextAccessor _sesion) : IUsuarioModel
    {

        public UsuarioRespuesta IniciarSesion(Usuario entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Usuario/IniciarSesion";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _http.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }

    }
}
