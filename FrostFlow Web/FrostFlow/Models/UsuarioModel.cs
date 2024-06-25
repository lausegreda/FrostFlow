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

        public UsuarioRespuesta RegistrarTecnico(Usuario entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Usuario/RegistrarTecnico";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _http.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }

        public UsuarioRespuesta ConsultarTecnicos()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Usuario/ConsultarTecnicos";
            //_http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _sesion.HttpContext?.Session.GetString("Token"));
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }

        public UsuarioRespuesta EliminarTecnico(int id_Usuario)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Usuario/EliminarTecnico?id_Usuario=" + id_Usuario;
            //_http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _sesion.HttpContext?.Session.GetString("Token"));
            var resp = _http.DeleteAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }

        public UsuarioRespuesta ConsultarTecnico(long id)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Usuario/ConsultarTecnico?id_Usuario=" + id;
            //_http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _sesion.HttpContext?.Session.GetString("Token"));
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }

        public UsuarioRespuesta ActualizarTecnico(Usuario entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Usuario/ActualizarTecnico";
            //_http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _sesion.HttpContext?.Session.GetString("Token"));
            JsonContent body = JsonContent.Create(entidad);
            var resp = _http.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }


        public UsuarioRespuesta CambiarContrasenna(Usuario entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Usuario/CambiarContrasenna";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _http.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }
    }
}
