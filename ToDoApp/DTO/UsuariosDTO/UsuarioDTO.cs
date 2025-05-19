using ToDoApp.Modelos;

namespace ToDoApp.DTO.UsuariosDTO
{
    public class UsuarioDTO
    {

        public string Nombre { get; set; } = null!;

        public string CorreoElectronico { get; set; } = null!;

        public byte[]? FotoPerfil { get; set; }

        public DateTime? UltimaVez { get; set; }

        public virtual ICollection<Todo> Todos { get; set; } = new List<Todo>();
    }
}
