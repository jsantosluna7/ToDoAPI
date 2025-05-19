using ToDoApp.DTO.UsuariosDTO;
using ToDoApp.Modelos;

namespace ToDoApp.Abstraccion.Repositorios
{
    public interface IRepositorioUsuarios
    {
        Task<Usuario?> IniciarSesion(Login login);
        Task<Usuario?> RegisterUser(CrearUsuarioDTO crearUsuarioDTO);
    }
}