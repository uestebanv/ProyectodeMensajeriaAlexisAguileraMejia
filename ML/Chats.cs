using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Chats
    {
        public int ChatsID { get; set; }
        public ML.Usuarios? Usuario1 { get; set; }
        public ML.Usuarios? Usuario2 { get; set; }
    }
}