using ToDoApp.Abstraccion.Repositorios;
using ToDoApp.Abstraccion.Servicios;
using ToDoApp.DTO.UsuariosDTO;
using ToDoApp.Modelos;

namespace ToDoApp.Implementaciones.Servicios
{
    public class ServicioUsuarios : IServicioUsuarios
    {
        private readonly IRepositorioUsuarios _repositorioUsuarios;

        public ServicioUsuarios(IRepositorioUsuarios repositorioUsuarios)
        {
            _repositorioUsuarios = repositorioUsuarios;
        }

        public async Task<UsuarioDTO?> IniciarSecion(Login login)
        {
            var usuario = await _repositorioUsuarios.IniciarSesion(login);
            if (usuario == null)
            {
                return null; // Usuario no encontrado o contraseña incorrecta
            }

            var inicio = new UsuarioDTO()
            {
                Nombre = usuario.Nombre,
                CorreoElectronico = usuario.CorreoElectronico,
                UltimaVez = usuario.UltimaVez,
                FotoPerfil = usuario.FotoPerfil,
                Todos = usuario.Todos
            };

            // Aquí puedes agregar lógica adicional si es necesario
            return inicio;
        }

        public async Task<CrearUsuarioDTO?> RegistrarUsuario(CrearUsuarioDTO crearUsuarioDTO)
        {
            var usuarioExistente = await _repositorioUsuarios.RegisterUser(crearUsuarioDTO);
            if (usuarioExistente == null)
            {
                return null; // El correo electrónico ya está registrado
            }
            // Crear un nuevo usuario
            var nuevoUsuario = new CrearUsuarioDTO
            {
                Nombre = crearUsuarioDTO.Nombre,
                CorreoElectronico = crearUsuarioDTO.CorreoElectronico,
                ContrasenaHash = crearUsuarioDTO.ContrasenaHash,
                FotoPerfil = crearUsuarioDTO.FotoPerfil
            };
            return nuevoUsuario;
        }
    }
}
