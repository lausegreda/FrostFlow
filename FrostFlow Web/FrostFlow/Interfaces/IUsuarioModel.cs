using FrostFlow.Entities;

namespace FrostFlow.Interfaces
{
    public interface IUsuarioModel
    {
        UsuarioRespuesta IniciarSesion(Usuario entidad);
    }
}
