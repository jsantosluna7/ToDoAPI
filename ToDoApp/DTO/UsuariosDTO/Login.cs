namespace ToDoApp.DTO.UsuariosDTO
{
    public class Login
    {
        public string CorreoElectronico { get; set; } = null!;

        public string ContrasenaHash { get; set; } = null!;
    }
}
