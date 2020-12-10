using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Usuario.DTO
{
    public class ChangePassRequest
    {
        public int Id_usuario { get; set; }
        public string Oldpass { get; set; }
        public string Newpass { get; set; }
    }
}
