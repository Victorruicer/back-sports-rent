using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Usuario.DTO
{
    public class UpdateUserResponse
    {
        public string Email { get; set; }
        public int Retcode { get; set; }
        public string Mensaje { get; set; }
    }
}
