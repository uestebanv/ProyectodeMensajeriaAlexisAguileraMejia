using System;
using System.Collections.Generic;

namespace DL;

public partial class Chat
{
    public int ChatsId { get; set; }

    public int? Usuario1 { get; set; }

    public int? Usuario2 { get; set; }

    public virtual ICollection<Mensaje> Mensajes { get; set; } = new List<Mensaje>();

    public virtual Usuario? Usuario1Navigation { get; set; }

    public virtual Usuario? Usuario2Navigation { get; set; }
}
