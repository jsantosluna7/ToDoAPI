using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ToDoApp.Modelos;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string ContrasenaHash { get; set; } = null!;

    public byte[]? FotoPerfil { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? UltimaVez { get; set; }

    public virtual ICollection<Todo> Todos { get; set; } = new List<Todo>();
}
