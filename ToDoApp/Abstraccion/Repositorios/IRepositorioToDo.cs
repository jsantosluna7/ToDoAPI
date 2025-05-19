using ToDoApp.DTO.ToDoDTO;
using ToDoApp.Modelos;

namespace ToDoApp.Abstraccion.Repositorios
{
    public interface IRepositorioToDo
    {
        //Task<Todo?> CreateTodo(ToDoDTO toDoDTO);
        Task<Todo?> CreateTodo(CrearToDoDTO crearToDoDTO);
        Task<Todo?> DesactivateTodo(int id);
        Task<Todo?> GetTodoById(int id);
        //Task<List<Todo>?> GetTodos();
        Task<List<Todo>?> GetTodos(int idUsuario);
        //Task<Todo?> UpdateTodo(int id, ToDoDTO toDoDTO);
        Task<Todo?> UpdateTodo(int id, UpdateToDoDTO toDoDTO);
    }
}