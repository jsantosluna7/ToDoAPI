using ToDoApp.Abstraccion.Repositorios;
using ToDoApp.Abstraccion.Servicios;
using ToDoApp.DTO.ToDoDTO;

namespace ToDoApp.Implementaciones.Servicios
{
    public class ServicioToDo : IServicioToDo
    {
        private readonly IRepositorioToDo _repositorioToDo;
        public ServicioToDo(IRepositorioToDo repositorioToDo)
        {
            _repositorioToDo = repositorioToDo;
        }


        // Método para obtener todos los ToDos
        public async Task<List<ToDoDTO>?> GetToDos(int idUsuario)
        {
            var todos = await _repositorioToDo.GetTodos(idUsuario);

            if (todos == null)
            {
                return null;
            }

            // Convertir la lista de ToDo a una lista de ToDoDTO

            var todoDTO = new List<ToDoDTO>();

            foreach (var todo in todos)
            {
                var newTodoDTO = new ToDoDTO
                {
                    Task = todo.Task
                };

                todoDTO.Add(newTodoDTO);
            }

            return todoDTO;
        }

        // Método para obtener un ToDo por su ID
        public async Task<ToDoDTO?> GetToDoById(int id)
        {
            var todo = await _repositorioToDo.GetTodoById(id);
            if (todo == null)
            {
                return null;
            }
            var todoDTO = new ToDoDTO
            {
                Task = todo.Task
            };
            return todoDTO;
        }

        // Método para crear un nuevo ToDo
        public async Task<CrearToDoDTO?> CreateToDo(CrearToDoDTO crearToDoDTO)
        {
            var todo = await _repositorioToDo.CreateTodo(crearToDoDTO);
            if (todo == null)
            {
                return null;
            }
            var newTodoDTO = new CrearToDoDTO
            {
                Task = todo.Task,
                IdUsuario = todo.IdUsuario
            };
            return newTodoDTO;
        }

        // Método para actualizar un ToDo
        public async Task<UpdateToDoDTO?> UpdateToDo(int id, UpdateToDoDTO updateToDoDTO)
        {
            var todo = await _repositorioToDo.UpdateTodo(id, updateToDoDTO);
            if (todo == null)
            {
                return null;
            }
            var newTodoDTO = new UpdateToDoDTO
            {
                Task = todo.Task
            };
            return newTodoDTO;
        }

        // Método para desactivar un ToDo
        public async Task<ToDoDTO?> DesactivateToDo(int id)
        {
            var todo = await _repositorioToDo.DesactivateTodo(id);
            if (todo == null)
            {
                return null;
            }
            var newTodoDTO = new ToDoDTO
            {
                Task = todo.Task
            };
            return newTodoDTO;
        }
    }
}
