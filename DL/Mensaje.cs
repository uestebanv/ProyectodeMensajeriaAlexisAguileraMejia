using System;
using System.Collections.Generic;

namespace DL;

public partial class Mensaje
{
    public int MensajesId { get; set; }

    public int? UsuariosId { get; set; }

    public int? ChatsId { get; set; }

    public string? Texto { get; set; }

    public DateTime? FechaHoraMensaje { get; set; }

    public virtual Chat? Chats { get; set; }

    public virtual Usuario? Usuarios { get; set; }
}
