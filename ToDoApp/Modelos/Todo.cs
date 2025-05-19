using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ToDoApp.Modelos;

public partial class Todo
{
    public int Id { get; set; }

    public string? Task { get; set; }

    public bool? Activado { get; set; }

    public int? IdUsuario { get; set; }
    [JsonIgnore]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
