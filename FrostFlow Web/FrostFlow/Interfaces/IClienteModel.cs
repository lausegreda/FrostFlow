using FrostFlow.Entities;

namespace FrostFlow.Interfaces
{
    public interface IClienteModel
    {
        ClienteRespuesta BuscarCliente(string identificacion);
        ClienteRespuesta ConsultarCliente(long IdCliente);
        ClienteRespuesta EliminarCliente(Cliente entidad);
        ClienteRespuesta ListadoClientes();
        ClienteRespuesta ModificarCliente(Cliente entidad);
        ClienteRespuesta RegistrarCliente(Cliente entidad);
    }
}