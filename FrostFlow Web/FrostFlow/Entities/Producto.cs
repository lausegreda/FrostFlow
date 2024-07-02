namespace FrostFlow.Entities
{
    public class Producto
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public int stock { get; set; }
        public decimal precio { get; set; }

    }
    public class ProductoRespuesta // Se agrega para manejo de mensajes estandarizados en las respuestas de la BD con el API
    {
        public ProductoRespuesta()
        {
            Codigo = "1";
            Mensaje = string.Empty;
            Dato = null;
            Datos = null;
        }

        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public Producto Dato { get; set; }
        public List<Producto> Datos { get; set; }
    }
}
