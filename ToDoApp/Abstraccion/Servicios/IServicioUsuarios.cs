using ToDoApp.DTO.UsuariosDTO;
using ToDoApp.Modelos;

namespace ToDoApp.Abstraccion.Servicios
{
    public interface IServicioUsuarios
    {
        //Task<Usuario?> IniciarSecion(Login login);
        Task<UsuarioDTO?> IniciarSecion(Login login);
        Task<CrearUsuarioDTO?> RegistrarUsuario(CrearUsuarioDTO crearUsuarioDTO);
    }
}