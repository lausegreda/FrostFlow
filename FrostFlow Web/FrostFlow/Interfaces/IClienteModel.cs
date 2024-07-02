using FrostFlow.Entities;

namespace FrostFlow.Interfaces
{
    public interface IClienteModel
    {
        ClienteRespuesta BuscarCliente(string identificacion);
        ClienteRespuesta ConsultarCliente(long id_cliente);
        ClienteRespuesta EliminarCliente(int id_cliente);
        ClienteRespuesta ListadoClientes();
        ClienteRespuesta ModificarCliente(Cliente entidad);
        ClienteRespuesta RegistrarCliente(Cliente entidad);
    }
}