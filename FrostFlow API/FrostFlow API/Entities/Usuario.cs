namespace FrostFlow_API.Entities
{
    public class Usuario
    {
        public int id_Usuario { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string contrasenna { get; set; }
        public string estado { get; set; }
        public int id_Rol { get; set; }
        public string nombreRol { get; set; }
    }

    public class UsuarioRespuesta // Se agrega para manejo de mensajes estandarizados en las respuestas de la BD con el API
    {
        public UsuarioRespuesta()
        {
            Codigo = "1";
            Mensaje = string.Empty;
            Dato = null;
            Datos = null;
        }

        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public Usuario? Dato { get; set; }
        public List<Usuario>? Datos { get; set; }
    }
}
