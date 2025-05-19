using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Abstraccion.Servicios;
using ToDoApp.DTO.UsuariosDTO;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IServicioUsuarios _servicioUsuarios;

        public UsuariosController(IServicioUsuarios servicioUsuarios)
        {
            _servicioUsuarios = servicioUsuarios;
        }

        [HttpPost("iniciar-sesion")]
        public async Task<IActionResult> IniciarSesion([FromBody] Login login)
        {
            var resultado = await _servicioUsuarios.IniciarSecion(login);
            if (resultado == null)
            {
                return NotFound("Usuario no encontrado o contraseña incorrecta.");
            }
            return Ok(resultado);
        }

        [HttpPost("registrar-usuario")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] CrearUsuarioDTO crearUsuarioDTO)
        {
            var resultado = await _servicioUsuarios.RegistrarUsuario(crearUsuarioDTO);
            if (resultado == null)
            {
                return BadRequest("El correo electrónico ya está registrado");
            }
            return Ok("Usuario registrado.");
        }

    }
}
