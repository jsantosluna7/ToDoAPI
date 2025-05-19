using Microsoft.EntityFrameworkCore;
using ToDoApp.Abstraccion.Repositorios;
using ToDoApp.DTO.UsuariosDTO;
using ToDoApp.Modelos;

namespace ToDoApp.Implementaciones.Repositorios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly DbToDoContext _context;
        public RepositorioUsuarios(DbToDoContext context)
        {
            _context = context;
        }

        //public async Task<Usuario?> GetUsuarioById(int id)
        //{
        //    var usuario = await _context.Usuarios
        //        .Include(u => u.Todos)
        //        .FirstOrDefaultAsync(u => u.Id == id);
        //    if (usuario == null)
        //    {
        //        return null;
        //    }
        //    return usuario;

        //}

        public async Task<Usuario?> IniciarSesion(Login login)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Todos)
                .FirstOrDefaultAsync(u => u.CorreoElectronico == login.CorreoElectronico);
            if (usuario == null)
            {
                return null; // Usuario no encontrado
            }
            // Verificar la contraseña
            if (!BCrypt.Net.BCrypt.Verify(login.ContrasenaHash, usuario.ContrasenaHash))
            {
                return null; // Contraseña incorrecta
            }

            // Si la contraseña es correcta, devolver el usuario y actualizar la fecha de última vez
            usuario.UltimaVez = DateTime.UtcNow;
            return usuario;
        }

        public async Task<Usuario?> RegisterUser(CrearUsuarioDTO crearUsuarioDTO)
        {
            var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.CorreoElectronico == crearUsuarioDTO.CorreoElectronico);
            if (usuarioExistente != null)
            {
                return null; // El correo electrónico ya está registrado
            }

            // Hash de la contraseña
            string hash = BCrypt.Net.BCrypt.HashPassword(crearUsuarioDTO.ContrasenaHash);

            // Crear un nuevo usuario
            var usuario = new Usuario
            {
                Nombre = crearUsuarioDTO.Nombre,
                CorreoElectronico = crearUsuarioDTO.CorreoElectronico,
                ContrasenaHash = hash,
                FotoPerfil = crearUsuarioDTO.FotoPerfil,
                FechaCreacion = DateTime.UtcNow,
                UltimaVez = DateTime.UtcNow
            };

            // Agregar el nuevo usuario a la base de datos
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
