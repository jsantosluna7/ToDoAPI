namespace ToDoApp.DTO.UsuariosDTO
{
    public class CrearUsuarioDTO
    {
        public string Nombre { get; set; } = null!;

        public string CorreoElectronico { get; set; } = null!;

        public string ContrasenaHash { get; set; } = null!;

        public byte[]? FotoPerfil { get; set; }
    }
}
