using ToDoApp.DTO.ToDoDTO;

namespace ToDoApp.Abstraccion.Servicios
{
    public interface IServicioToDo
    {
        //Task<ToDoDTO?> CreateToDo(ToDoDTO toDoDTO);
        Task<CrearToDoDTO?> CreateToDo(CrearToDoDTO crearToDoDTO);
        Task<ToDoDTO?> DesactivateToDo(int id);
        Task<ToDoDTO?> GetToDoById(int id);
        //Task<List<ToDoDTO>?> GetToDos();
        Task<List<ToDoDTO>?> GetToDos(int idUsuario);
        //Task<ToDoDTO?> UpdateToDo(int id, ToDoDTO toDoDTO);
        Task<UpdateToDoDTO?> UpdateToDo(int id, UpdateToDoDTO updateToDoDTO);
    }
}