﻿namespace FrostFlow_API.Entities
{
    public class Cliente
    {
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public string identificacion { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
    }

    public class ClienteRespuesta // Se agrega para manejo de mensajes estandarizados en las respuestas de la BD con el API
    {
        public ClienteRespuesta()
        {
            Codigo = "1";
            Mensaje = string.Empty;
            Dato = null;
            Datos = null;
        }

        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public Cliente? Dato { get; set; }
        public List<Cliente>? Datos { get; set; }
    }
}