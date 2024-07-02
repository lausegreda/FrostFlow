using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;
using FrostFlow.Entities;
using FrostFlow.Interfaces;

namespace FrostFlow.Models
{
    public class ClienteModel(HttpClient _http, IConfiguration _configuration, IHttpContextAccessor _sesion) : IClienteModel
    {
        public ClienteRespuesta RegistrarCliente(Cliente entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Cliente/RegistrarCliente";
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _sesion.HttpContext?.Session.GetString("Token"));
            JsonContent body = JsonContent.Create(entidad);
            var resp = _http.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ClienteRespuesta>().Result;

            return null;
        }

        public ClienteRespuesta BuscarCliente(string identificacion)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + $"api/Cliente/buscarCliente?identificacion={identificacion}";
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _sesion.HttpContext?.Session.GetString("Token"));
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ClienteRespuesta>().Result;

            return null;
        }

        public ClienteRespuesta ListadoClientes()
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + $"api/Cliente/ListadoClientes";
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _sesion.HttpContext?.Session.GetString("Token"));
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ClienteRespuesta>().Result;

            return null;
        }

        public ClienteRespuesta EliminarCliente(int id_cliente)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Usuario/EliminarCliente?id_cliente=" + id_cliente;
            var resp = _http.DeleteAsync(url).Result;

            if (resp.IsSuccessStatusCode)
            {
                var result = resp.Content.ReadFromJsonAsync<ClienteRespuesta>().Result;
                return result;
            }

            return null;
        }

        public ClienteRespuesta ModificarCliente(Cliente entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Usuario/ModificarCliente";
            //_http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _sesion.HttpContext?.Session.GetString("Token"));
            JsonContent body = JsonContent.Create(entidad);
            var resp = _http.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ClienteRespuesta>().Result;

            return null;
        }


        public ClienteRespuesta ConsultarCliente(long IdCliente)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + $"api/Cliente/ConsultarCliente?IdCliente={IdCliente}";
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _sesion.HttpContext?.Session.GetString("Token"));
            var resp = _http.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<ClienteRespuesta>().Result;

            return null;
        }
    }
}
