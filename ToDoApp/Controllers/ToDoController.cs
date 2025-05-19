using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Abstraccion.Servicios;
using ToDoApp.DTO.ToDoDTO;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IServicioToDo _servicioToDo;
        public ToDoController(IServicioToDo servicioToDo)
        {
            _servicioToDo = servicioToDo;
        }

        // Método para obtener todos los ToDos
        [HttpGet("obtener-todos/{idUsuario}")]
        public async Task<IActionResult> GetToDos(int idUsuario)
        {
            var todos = await _servicioToDo.GetToDos(idUsuario);
            if (todos == null)
            {
                return NotFound();
            }
            return Ok(todos);
        }


        // Método para obtener un ToDo por su ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoById(int id)
        {
            var todo = await _servicioToDo.GetToDoById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }


        // Método para crear un nuevo ToDo
        [HttpPost]
        public async Task<IActionResult> CreateToDo([FromBody] CrearToDoDTO crearToDoDTO)
        {
            if (crearToDoDTO == null)
            {
                return BadRequest();
            }

            // Validar el modelo
            var todo = await _servicioToDo.CreateToDo(crearToDoDTO);
            if (todo == null)
            {
                return BadRequest();
            }
            return Ok();
        }


        // Método para actualizar un ToDo
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDo(int id, [FromBody] UpdateToDoDTO updateToDoDTO)
        {
            if (updateToDoDTO == null)
            {
                return BadRequest();
            }
            var todo = await _servicioToDo.UpdateToDo(id, updateToDoDTO);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        // Método para desactivar un ToDo
        [HttpDelete("{id}")]
        public async Task<IActionResult> DesactivateToDo(int id)
        {
            var todo = await _servicioToDo.DesactivateToDo(id);
            if (todo == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
