using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int UsuariosId { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public int? Edad { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Imagen { get; set; }

    public virtual ICollection<Chat> ChatUsuario1Navigations { get; set; } = new List<Chat>();

    public virtual ICollection<Chat> ChatUsuario2Navigations { get; set; } = new List<Chat>();

    public virtual ICollection<Mensaje> Mensajes { get; set; } = new List<Mensaje>();
}
