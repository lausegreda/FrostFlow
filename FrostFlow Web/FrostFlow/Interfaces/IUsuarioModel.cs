using FrostFlow.Entities;

namespace FrostFlow.Interfaces
{
    public interface IUsuarioModel
    {
        UsuarioRespuesta IniciarSesion(Usuario entidad);

        UsuarioRespuesta RegistrarTecnico(Usuario entidad);
        public UsuarioRespuesta ConsultarTecnicos();
        UsuarioRespuesta EliminarTecnico(int id_Usuario);
        UsuarioRespuesta ActualizarTecnico(Usuario entidad);
        UsuarioRespuesta ConsultarTecnico(long id_Usuario);
    }
}
