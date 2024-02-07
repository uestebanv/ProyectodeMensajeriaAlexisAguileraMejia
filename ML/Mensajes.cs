using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Mensajes
    {
        public int MensajesID {  get; set; }
        public ML.Usuarios? Usuarios { get; set; }
        public ML.Chats? Chats { get; set; }
        public string? Texto { get; set; }
        public DateTime? FechaHoraMensaje { get; set; }
    }
}