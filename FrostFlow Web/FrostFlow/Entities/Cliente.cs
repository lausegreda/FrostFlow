namespace FrostFlow.Entities
{
    public class Cliente
    {
        public int id_cliente { get; set; }
        public string? nombre { get; set; }
        public string? identificacion { get; set; }
        public string? direccion { get; set; }
        public string? telefono { get; set; }

    }

    public class ClienteRespuesta
    {
        public ClienteRespuesta()
        {
            Codigo = "00";
            Mensaje = "";
            Dato = null;
            Datos = null;
        }

        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public Cliente? Dato { get; set; }
        public List<Cliente>? Datos { get; set; }
    }
}
