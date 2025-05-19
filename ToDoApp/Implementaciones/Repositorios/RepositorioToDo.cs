using Microsoft.EntityFrameworkCore;
using ToDoApp.Abstraccion.Repositorios;
using ToDoApp.DTO.ToDoDTO;
using ToDoApp.Modelos;

namespace ToDoApp.Implementaciones.Repositorios
{
    public class RepositorioToDo : IRepositorioToDo
    {
        private readonly DbToDoContext _context;

        public RepositorioToDo(DbToDoContext context)
        {
            _context = context;
        }

        /// Método para obtener todo un nuevo ToDo
        public async Task<List<Todo>?> GetTodos(int idUsuario)
        {
            var todo = await _context.Todos
                .Where(t => t.Activado == true && t.IdUsuario == idUsuario)
                .ToListAsync();

            if (todo == null)
            {
                return null;
            }

            return todo;
        }

        // Método para obtener un ToDo por su ID
        public async Task<Todo?> GetTodoById(int id)
        {
            var todo = await _context.Todos
                .Where(t => t.Activado == true && t.Id == id)
                .FirstOrDefaultAsync();
            if (todo == null)
            {
                return null;
            }
            return todo;
        }

        // Método para crear un nuevo ToDo
        public async Task<Todo?> CreateTodo(CrearToDoDTO crearToDoDTO)
        {
            var todo = new Todo
            {
                Task = crearToDoDTO.Task,
                IdUsuario = crearToDoDTO.IdUsuario,
                Activado = true
            };
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        // Método para actualizar un nuevo ToDo
        public async Task<Todo?> UpdateTodo(int id, UpdateToDoDTO toDoDTO)
        {
            var usuario = await GetTodoById(id);
            if (usuario == null)
            {
                return null;
            }

            usuario.Task = toDoDTO.Task ?? usuario.Task;
            return usuario;
        }

        // Método para desactivar un ToDo
        public async Task<Todo?> DesactivateTodo(int id)
        {
            var todo = await GetTodoById(id);
            if (todo == null)
            {
                return null;
            }

            todo.Activado = false;
            return todo;
        }
    }
}
